using System.Data;
using System.Data.SqlClient;

namespace QLKhoAChau.DAL
{
    public static class PhieuXuatDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery(@"
                SELECT p.MaPX, p.SoPhieu, p.NgayXuat, kh.TenKH, nd.HoTen AS NguoiXuat,
                       p.TongTien, p.GhiChu
                FROM PhieuXuat p
                JOIN KhachHang kh ON kh.MaKH=p.MaKH
                JOIN NguoiDung nd ON nd.MaND=p.MaND
                ORDER BY p.NgayXuat DESC");

        public static DataTable GetChiTiet(int maPX) =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaSP, h.TenHH, ct.SoLuong, ct.DonGia, ct.ThanhTien
                FROM ChiTietXuat ct JOIN HangHoa h ON h.MaHH=ct.MaHH
                WHERE ct.MaPX=@id",
                new SqlParameter("@id", maPX));

        public static DataTable GetKH() =>
            DBHelper.ExecuteQuery("SELECT MaKH, TenKH FROM KhachHang ORDER BY TenKH");

        public static int Insert(string soPhieu, int maKH, int maND, string ghiChu,
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
                            "INSERT INTO PhieuXuat(SoPhieu,MaKH,MaND,GhiChu) OUTPUT INSERTED.MaPX VALUES(@s,@k,@u,@g)",
                            conn, tran);
                        cmd.Parameters.AddWithValue("@s", soPhieu);
                        cmd.Parameters.AddWithValue("@k", maKH);
                        cmd.Parameters.AddWithValue("@u", maND);
                        cmd.Parameters.AddWithValue("@g", (object)ghiChu ?? System.DBNull.Value);
                        int maPX = (int)cmd.ExecuteScalar();

                        foreach (DataRow r in chiTiet.Rows)
                        {
                            var c = new SqlCommand(
                                "INSERT INTO ChiTietXuat(MaPX,MaHH,SoLuong,DonGia) VALUES(@p,@h,@s,@d)",
                                conn, tran);
                            c.Parameters.AddWithValue("@p", maPX);
                            c.Parameters.AddWithValue("@h", r["MaHH"]);
                            c.Parameters.AddWithValue("@s", r["SoLuong"]);
                            c.Parameters.AddWithValue("@d", r["DonGia"]);
                            c.ExecuteNonQuery();
                        }
                        tran.Commit();
                        return maPX;
                    }
                    catch { tran.Rollback(); throw; }
                }
            }
        }

        public static string SinhSoPhieu()
        {
            var o = DBHelper.ExecuteScalar("SELECT COUNT(*)+1 FROM PhieuXuat");
            return "PX" + ((int)o).ToString("D4");
        }
    }
}
