using System.Data;
using System.Data.SqlClient;

namespace QLKhoAChau.DAL
{
    public static class HangHoaDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaHH, h.MaSP, h.TenHH, dm.TenDM, h.DonViTinh,
                       h.GiaNhap, h.GiaBan, h.TonKho, h.TonToiThieu,
                       h.NgaySanXuat, h.HanSuDung, h.NgayNhapLo, h.TrangThaiLo, ncc.TenNCC
                FROM HangHoa h JOIN DanhMuc dm ON dm.MaDM=h.MaDM
                LEFT JOIN NhaCungCap ncc ON ncc.MaNCC=h.MaNCC
                WHERE h.TrangThai=1
                ORDER BY
                    CASE
                        WHEN h.HanSuDung < CAST(GETDATE() AS DATE)                   THEN 3
                        WHEN h.TrangThaiLo = N'Huy'                                  THEN 3
                        WHEN h.HanSuDung <= CAST(DATEADD(DAY,7,GETDATE()) AS DATE)   THEN 2
                        ELSE 1
                    END ASC,
                    h.HanSuDung ASC, h.MaSP ASC");

        public static DataTable Search(string kw) =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaHH, h.MaSP, h.TenHH, dm.TenDM, h.DonViTinh,
                       h.GiaNhap, h.GiaBan, h.TonKho, h.TonToiThieu,
                       h.NgaySanXuat, h.HanSuDung, h.NgayNhapLo, h.TrangThaiLo, ncc.TenNCC
                FROM HangHoa h JOIN DanhMuc dm ON dm.MaDM=h.MaDM
                LEFT JOIN NhaCungCap ncc ON ncc.MaNCC=h.MaNCC
                WHERE h.TrangThai=1 AND (h.MaSP LIKE @k OR h.TenHH LIKE @k)
                ORDER BY
                    CASE
                        WHEN h.HanSuDung < CAST(GETDATE() AS DATE)                   THEN 3
                        WHEN h.TrangThaiLo = N'Huy'                                  THEN 3
                        WHEN h.HanSuDung <= CAST(DATEADD(DAY,7,GETDATE()) AS DATE)   THEN 2
                        ELSE 1
                    END ASC,
                    h.HanSuDung ASC, h.MaSP ASC",
                new SqlParameter("@k", "%" + kw + "%"));

        public static DataTable GetForCombo() =>
            DBHelper.ExecuteQuery("SELECT MaHH, MaSP + ' - ' + TenHH AS TenHienThi, GiaNhap, GiaBan, TonKho FROM HangHoa WHERE TrangThai=1 ORDER BY MaSP");

        // Trả danh sách MaSP phân biệt cho ComboBox frmPhieuNhap (chọn SP cũ)
        public static DataTable GetDanhSachSP() =>
            DBHelper.ExecuteQuery(@"
                SELECT DISTINCT h.MaSP,
                       h.MaSP + N' - ' + h.TenHH AS TenHienThi,
                       h.MaDM, h.MaNCC, h.DonViTinh
                FROM HangHoa h WHERE h.TrangThai=1 ORDER BY h.MaSP");

        // Trả lô còn tồn > 0 cho ComboBox frmPhieuXuat
        // Hiển thị: "ID - MaSP - TenHH - HSD: dd/MM/yyyy"
        public static DataTable GetLoForXuatCombo() =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaHH,
                       CAST(h.MaHH AS NVARCHAR(10)) + N' - ' + h.MaSP + N' - ' + h.TenHH
                           + N' - HSD: ' + CONVERT(NVARCHAR(10), h.HanSuDung, 103) AS TenHienThi,
                       h.GiaBan, h.TonKho, h.HanSuDung, h.TrangThaiLo, h.MaSP
                FROM HangHoa h WHERE h.TrangThai=1 AND h.TonKho>0
                ORDER BY CASE WHEN h.HanSuDung < CAST(GETDATE() AS DATE) THEN 2 ELSE 1 END, h.HanSuDung ASC");

        // Gợi ý lô HSD sớm nhất cùng MaSP (FIFO) cho label frmPhieuXuat
        public static DataTable GetLoFIFOByMaSP(string maSP) =>
            DBHelper.ExecuteQuery(@"
                SELECT TOP 1 h.MaHH, h.MaSP, h.TenHH, h.HanSuDung, h.TonKho
                FROM HangHoa h WHERE h.TrangThai=1 AND h.TonKho>0 AND h.MaSP=@maSP
                ORDER BY h.HanSuDung ASC",
                new SqlParameter("@maSP", maSP));

        public static int Insert(string maSP, string ten, int maDM, int maNCC, string dvt,
            decimal giaNhap, decimal giaBan, int tonToiThieu, DateTime ngaySX, DateTime hanSD,
            int soLuong, DateTime ngayNhapLo)
        {
            return DBHelper.ExecuteNonQuery(@"
                INSERT INTO HangHoa(MaSP,TenHH,MaDM,MaNCC,DonViTinh,GiaNhap,GiaBan,
                                    TonToiThieu,NgaySanXuat,HanSuDung,TonKho,NgayNhapLo,TrangThaiLo)
                VALUES(@s,@t,@d,@n,@v,@gn,@gb,@tt,@nx,@hs,@sl,@nl,N'BinhThuong')",
                new SqlParameter("@s", maSP), new SqlParameter("@t", ten),
                new SqlParameter("@d", maDM), new SqlParameter("@n", maNCC), new SqlParameter("@v", dvt),
                new SqlParameter("@gn", giaNhap), new SqlParameter("@gb", giaBan),
                new SqlParameter("@tt", tonToiThieu),
                new SqlParameter("@nx", ngaySX), new SqlParameter("@hs", hanSD),
                new SqlParameter("@sl", soLuong), new SqlParameter("@nl", ngayNhapLo));
        }

        // Giống Insert nhưng trả về MaHH vừa tạo — dùng trong PhieuNhapDAL
        public static int InsertAndGetId(string maSP, string ten, int maDM, int maNCC, string dvt,
            decimal giaNhap, decimal giaBan, int tonToiThieu, DateTime ngaySX, DateTime hanSD,
            int soLuong, DateTime ngayNhapLo)
        {
            var result = DBHelper.ExecuteScalar(@"
                INSERT INTO HangHoa(MaSP,TenHH,MaDM,MaNCC,DonViTinh,GiaNhap,GiaBan,
                                    TonToiThieu,NgaySanXuat,HanSuDung,TonKho,NgayNhapLo,TrangThaiLo)
                OUTPUT INSERTED.MaHH
                VALUES(@s,@t,@d,@n,@v,@gn,@gb,@tt,@nx,@hs,@sl,@nl,N'BinhThuong')",
                new SqlParameter("@s", maSP), new SqlParameter("@t", ten),
                new SqlParameter("@d", maDM), new SqlParameter("@n", maNCC), new SqlParameter("@v", dvt),
                new SqlParameter("@gn", giaNhap), new SqlParameter("@gb", giaBan),
                new SqlParameter("@tt", tonToiThieu),
                new SqlParameter("@nx", ngaySX), new SqlParameter("@hs", hanSD),
                new SqlParameter("@sl", soLuong), new SqlParameter("@nl", ngayNhapLo));
            return (int)result;
        }

        public static int Update(int maHH, string maSP, string ten, int maDM, int maNCC, string dvt,
            decimal giaNhap, decimal giaBan, int tonToiThieu, DateTime ngaySX, DateTime hanSD)
        {
            return DBHelper.ExecuteNonQuery(@"
                UPDATE HangHoa SET MaSP=@s,TenHH=@t,MaDM=@d,MaNCC=@n,DonViTinh=@v,
                GiaNhap=@gn,GiaBan=@gb,TonToiThieu=@tt,NgaySanXuat=@nx,HanSuDung=@hs WHERE MaHH=@id",
                new SqlParameter("@id", maHH), new SqlParameter("@s", maSP),
                new SqlParameter("@t", ten), new SqlParameter("@d", maDM), new SqlParameter("@n", maNCC),
                new SqlParameter("@v", dvt), new SqlParameter("@gn", giaNhap),
                new SqlParameter("@gb", giaBan), new SqlParameter("@tt", tonToiThieu), 
                new SqlParameter("@nx", ngaySX), new SqlParameter("@hs", hanSD));
        }

        public static int Delete(int maHH) =>
            DBHelper.ExecuteNonQuery("UPDATE HangHoa SET TrangThai=0 WHERE MaHH=@id",
                new SqlParameter("@id", maHH));

        public static DataTable GetTonKho() =>
            DBHelper.ExecuteQuery("SELECT * FROM vw_NhapXuatTon ORDER BY TenHH");

        public static DataTable GetCanhBao() =>
            DBHelper.ExecuteQuery("EXEC sp_CanhBaoTonThap");
    }
}
