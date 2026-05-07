using System.Data;
using System.Data.SqlClient;

namespace QLKhoAChau.DAL
{
    public static class PhieuNhapDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery(@"
                SELECT p.MaPN, p.SoPhieu, p.NgayNhap, ncc.TenNCC, nd.HoTen AS NguoiNhap,
                       p.TongTien, p.GhiChu
                FROM PhieuNhap p
                JOIN NhaCungCap ncc ON ncc.MaNCC=p.MaNCC
                JOIN NguoiDung nd ON nd.MaND=p.MaND
                ORDER BY p.NgayNhap DESC");

        public static DataTable GetChiTiet(int maPN) =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaSP, h.TenHH, ct.SoLuong, ct.DonGia, ct.ThanhTien
                FROM ChiTietNhap ct JOIN HangHoa h ON h.MaHH=ct.MaHH
                WHERE ct.MaPN=@id",
                new SqlParameter("@id", maPN));

        public static DataTable GetNCC() =>
            DBHelper.ExecuteQuery("SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC");

        public static int Insert(string soPhieu, int maNCC, int maND, string ghiChu,
            DataTable chiTiet)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var cmd = new SqlCommand(
                            "INSERT INTO PhieuNhap(SoPhieu,MaNCC,MaND,GhiChu) OUTPUT INSERTED.MaPN VALUES(@s,@n,@u,@g)",
                            conn, tran);
                        cmd.Parameters.AddWithValue("@s", soPhieu);
                        cmd.Parameters.AddWithValue("@n", maNCC);
                        cmd.Parameters.AddWithValue("@u", maND);
                        cmd.Parameters.AddWithValue("@g", (object)ghiChu ?? System.DBNull.Value);
                        int maPN = (int)cmd.ExecuteScalar();

                        foreach (DataRow r in chiTiet.Rows)
                        {
                            var c = new SqlCommand(
                                "INSERT INTO ChiTietNhap(MaPN,MaHH,SoLuong,DonGia) VALUES(@p,@h,@s,@d)",
                                conn, tran);
                            c.Parameters.AddWithValue("@p", maPN);
                            c.Parameters.AddWithValue("@h", r["MaHH"]);
                            c.Parameters.AddWithValue("@s", r["SoLuong"]);
                            c.Parameters.AddWithValue("@d", r["DonGia"]);
                            c.ExecuteNonQuery();
                        }
                        tran.Commit();
                        return maPN;
                    }
                    catch { tran.Rollback(); throw; }
                }
            }
        }

        public static string SinhSoPhieu()
        {
            var o = DBHelper.ExecuteScalar("SELECT COUNT(*)+1 FROM PhieuNhap");
            return "PN" + ((int)o).ToString("D4");
        }
    }
}
