using System.Data;
using System.Data.SqlClient;

namespace QLKhoAChau.DAL
{
    public static class PhieuXuatDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery(@"
                SELECT p.MaPX, p.SoPhieu, p.NgayXuat, kh.TenKH, nd.HoTen AS NguoiXuat,
                       p.TongTien, p.GhiChu, p.LoaiPhieu
                FROM PhieuXuat p
                JOIN KhachHang kh ON kh.MaKH=p.MaKH
                JOIN NguoiDung nd ON nd.MaND=p.MaND
                ORDER BY p.NgayXuat DESC");

        // Tìm kiếm theo SoPhieu, TenKH, LoaiPhieu
        public static DataTable Search(string kw) =>
            DBHelper.ExecuteQuery(@"
                SELECT p.MaPX, p.SoPhieu, p.NgayXuat, kh.TenKH, nd.HoTen AS NguoiXuat,
                       p.TongTien, p.GhiChu, p.LoaiPhieu
                FROM PhieuXuat p
                JOIN KhachHang kh ON kh.MaKH=p.MaKH
                JOIN NguoiDung nd ON nd.MaND=p.MaND
                WHERE p.SoPhieu LIKE @k OR kh.TenKH LIKE @k OR p.LoaiPhieu LIKE @k
                ORDER BY p.NgayXuat DESC",
                new SqlParameter("@k", "%" + kw + "%"));

        // Lọc kết hợp: từ khóa + khoảng ngày + loại phiếu
        public static DataTable Filter(string kw, DateTime? tuNgay, DateTime? denNgay, string loaiPhieu) =>
            DBHelper.ExecuteQuery(@"
                SELECT p.MaPX, p.SoPhieu, p.NgayXuat, kh.TenKH, nd.HoTen AS NguoiXuat,
                       p.TongTien, p.GhiChu, p.LoaiPhieu
                FROM PhieuXuat p
                JOIN KhachHang kh ON kh.MaKH=p.MaKH
                JOIN NguoiDung nd ON nd.MaND=p.MaND
                WHERE (@k   IS NULL OR p.SoPhieu LIKE @k OR kh.TenKH LIKE @k)
                  AND (@tu  IS NULL OR CAST(p.NgayXuat AS DATE) >= @tu)
                  AND (@den IS NULL OR CAST(p.NgayXuat AS DATE) <= @den)
                  AND (@lp  IS NULL OR p.LoaiPhieu = @lp)
                ORDER BY p.NgayXuat DESC",
                new SqlParameter("@k",   string.IsNullOrWhiteSpace(kw)        ? (object)DBNull.Value : "%" + kw + "%"),
                new SqlParameter("@tu",  tuNgay.HasValue  ? (object)tuNgay.Value.Date  : DBNull.Value),
                new SqlParameter("@den", denNgay.HasValue ? (object)denNgay.Value.Date : DBNull.Value),
                new SqlParameter("@lp",  string.IsNullOrWhiteSpace(loaiPhieu) ? (object)DBNull.Value : loaiPhieu));

        public static DataTable GetChiTiet(int maPX) =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaHH, h.MaSP, h.TenHH, ct.SoLuong, ct.DonGia, ct.ThanhTien,
                       h.HanSuDung
                FROM ChiTietXuat ct JOIN HangHoa h ON h.MaHH=ct.MaHH
                WHERE ct.MaPX=@id",
                new SqlParameter("@id", maPX));

        public static DataTable GetKH() =>
            DBHelper.ExecuteQuery("SELECT MaKH, TenKH FROM KhachHang ORDER BY TenKH");

        // Thêm khách hàng mới — trả về MaKH vừa tạo
        public static int InsertKH(string tenKH, string diaChi, string dienThoai, string email)
        {
            var result = DBHelper.ExecuteScalar(@"
                INSERT INTO KhachHang(TenKH, DiaChi, DienThoai, Email)
                OUTPUT INSERTED.MaKH
                VALUES(@t, @d, @dt, @e)",
                new SqlParameter("@t",  tenKH),
                new SqlParameter("@d",  string.IsNullOrWhiteSpace(diaChi)     ? (object)DBNull.Value : diaChi),
                new SqlParameter("@dt", string.IsNullOrWhiteSpace(dienThoai)  ? (object)DBNull.Value : dienThoai),
                new SqlParameter("@e",  string.IsNullOrWhiteSpace(email)      ? (object)DBNull.Value : email));
            return (int)result;
        }

        public static int Insert(string soPhieu, int maKH, int maND, string ghiChu,
            DataTable chiTiet, string loaiPhieu = "XuatBan")
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var cmd = new SqlCommand(
                            "INSERT INTO PhieuXuat(SoPhieu,MaKH,MaND,GhiChu,LoaiPhieu) OUTPUT INSERTED.MaPX VALUES(@s,@k,@u,@g,@lp)",
                            conn, tran);
                        cmd.Parameters.AddWithValue("@s",  soPhieu);
                        cmd.Parameters.AddWithValue("@k",  maKH);
                        cmd.Parameters.AddWithValue("@u",  maND);
                        cmd.Parameters.AddWithValue("@g",  (object)ghiChu ?? System.DBNull.Value);
                        cmd.Parameters.AddWithValue("@lp", loaiPhieu);
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

        // Tạo số phiếu riêng cho phiếu xuất hủy
        public static string SinhSoPhieuHuy()
        {
            var o = DBHelper.ExecuteScalar("SELECT COUNT(*)+1 FROM PhieuXuat WHERE LoaiPhieu=N'XuatHuy'");
            return "PH" + ((int)o).ToString("D4");
        }
    }
}
