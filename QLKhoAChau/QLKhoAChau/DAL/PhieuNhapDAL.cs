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

        // Tìm kiếm theo SoPhieu, TenNCC hoặc NgayNhap
        public static DataTable Search(string kw) =>
            DBHelper.ExecuteQuery(@"
                SELECT p.MaPN, p.SoPhieu, p.NgayNhap, ncc.TenNCC, nd.HoTen AS NguoiNhap,
                       p.TongTien, p.GhiChu
                FROM PhieuNhap p
                JOIN NhaCungCap ncc ON ncc.MaNCC=p.MaNCC
                JOIN NguoiDung nd ON nd.MaND=p.MaND
                WHERE p.SoPhieu LIKE @k OR ncc.TenNCC LIKE @k
                ORDER BY p.NgayNhap DESC",
                new SqlParameter("@k", "%" + kw + "%"));

        // Lọc kết hợp: từ khóa + khoảng ngày (truyền null để bỏ qua từng điều kiện)
        public static DataTable Filter(string kw, DateTime? tuNgay, DateTime? denNgay) =>
            DBHelper.ExecuteQuery(@"
                SELECT p.MaPN, p.SoPhieu, p.NgayNhap, ncc.TenNCC, nd.HoTen AS NguoiNhap,
                       p.TongTien, p.GhiChu
                FROM PhieuNhap p
                JOIN NhaCungCap ncc ON ncc.MaNCC=p.MaNCC
                JOIN NguoiDung nd ON nd.MaND=p.MaND
                WHERE (@k  IS NULL OR p.SoPhieu LIKE @k OR ncc.TenNCC LIKE @k)
                  AND (@tu IS NULL OR CAST(p.NgayNhap AS DATE) >= @tu)
                  AND (@den IS NULL OR CAST(p.NgayNhap AS DATE) <= @den)
                ORDER BY p.NgayNhap DESC",
                new SqlParameter("@k",   string.IsNullOrWhiteSpace(kw) ? (object)DBNull.Value : "%" + kw + "%"),
                new SqlParameter("@tu",  tuNgay.HasValue  ? (object)tuNgay.Value.Date  : DBNull.Value),
                new SqlParameter("@den", denNgay.HasValue ? (object)denNgay.Value.Date : DBNull.Value));

        public static DataTable GetChiTiet(int maPN) =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaHH, h.MaSP, h.TenHH, ct.SoLuong, ct.DonGia, ct.ThanhTien,
                       h.HanSuDung, h.NgaySanXuat, h.NgayNhapLo
                FROM ChiTietNhap ct JOIN HangHoa h ON h.MaHH=ct.MaHH
                WHERE ct.MaPN=@id",
                new SqlParameter("@id", maPN));

        public static DataTable GetNCC() =>
            DBHelper.ExecuteQuery("SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC");

        public static int Insert(string soPhieu, int maNCC, int maND, string ghiChu,
            DataTable chiTiet)
        {
            // chiTiet cần có cột: MaSP, TenHH, MaDM, MaNCC, DonViTinh, GiaNhap, GiaBan,
            //                     TonToiThieu, NgaySanXuat, HanSuDung, SoLuong, DonGia
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

                        System.DateTime ngayNhapLo = System.DateTime.Now;

                        foreach (DataRow r in chiTiet.Rows)
                        {
                            // 1. Tạo dòng HangHoa mới — lô độc lập
                            var cmdHH = new SqlCommand(@"
                                INSERT INTO HangHoa(MaSP,TenHH,MaDM,MaNCC,DonViTinh,GiaNhap,GiaBan,
                                                    TonToiThieu,NgaySanXuat,HanSuDung,TonKho,NgayNhapLo,TrangThaiLo)
                                OUTPUT INSERTED.MaHH
                                VALUES(@s,@t,@d,@n,@v,@gn,@gb,@tt,@nx,@hs,@sl,@nl,N'BinhThuong')",
                                conn, tran);
                            cmdHH.Parameters.AddWithValue("@s",  r["MaSP"]);
                            cmdHH.Parameters.AddWithValue("@t",  r["TenHH"]);
                            cmdHH.Parameters.AddWithValue("@d",  r["MaDM"]);
                            cmdHH.Parameters.AddWithValue("@n",  r["MaNCC"]);
                            cmdHH.Parameters.AddWithValue("@v",  r["DonViTinh"]);
                            cmdHH.Parameters.AddWithValue("@gn", r["GiaNhap"]);
                            cmdHH.Parameters.AddWithValue("@gb", r["GiaBan"]);
                            cmdHH.Parameters.AddWithValue("@tt", r["TonToiThieu"]);
                            cmdHH.Parameters.AddWithValue("@nx", r["NgaySanXuat"]);
                            cmdHH.Parameters.AddWithValue("@hs", r["HanSuDung"]);
                            cmdHH.Parameters.AddWithValue("@sl", r["SoLuong"]);
                            cmdHH.Parameters.AddWithValue("@nl", ngayNhapLo);
                            int maHHMoi = (int)cmdHH.ExecuteScalar();

                            // 2. Ghi ChiTietNhap với MaHH lô mới
                            var c = new SqlCommand(
                                "INSERT INTO ChiTietNhap(MaPN,MaHH,SoLuong,DonGia) VALUES(@p,@h,@s,@d)",
                                conn, tran);
                            c.Parameters.AddWithValue("@p", maPN);
                            c.Parameters.AddWithValue("@h", maHHMoi);
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
