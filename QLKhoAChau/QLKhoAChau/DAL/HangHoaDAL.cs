using System.Data;
using System.Data.SqlClient;

namespace QLKhoAChau.DAL
{
    public static class HangHoaDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaHH, h.MaSP, h.TenHH, dm.TenDM, h.DonViTinh,
                       h.GiaNhap, h.GiaBan, h.TonKho, h.TonToiThieu, h.NgaySanXuat, h.HanSuDung, ncc.TenNCC
                FROM HangHoa h JOIN DanhMuc dm ON dm.MaDM=h.MaDM
                LEFT JOIN NhaCungCap ncc ON ncc.MaNCC=h.MaNCC
                WHERE h.TrangThai=1 ORDER BY h.MaSP");

        public static DataTable Search(string kw) =>
            DBHelper.ExecuteQuery(@"
                SELECT h.MaHH, h.MaSP, h.TenHH, dm.TenDM, h.DonViTinh,
                       h.GiaNhap, h.GiaBan, h.TonKho, h.TonToiThieu, h.NgaySanXuat, h.HanSuDung, ncc.TenNCC
                FROM HangHoa h JOIN DanhMuc dm ON dm.MaDM=h.MaDM
                LEFT JOIN NhaCungCap ncc ON ncc.MaNCC=h.MaNCC
                WHERE h.TrangThai=1 AND (h.MaSP LIKE @k OR h.TenHH LIKE @k)
                ORDER BY h.MaSP",
                new SqlParameter("@k", "%" + kw + "%"));

        public static DataTable GetForCombo() =>
            DBHelper.ExecuteQuery("SELECT MaHH, MaSP + ' - ' + TenHH AS TenHienThi, GiaNhap, GiaBan, TonKho FROM HangHoa WHERE TrangThai=1 ORDER BY MaSP");

        public static int Insert(string maSP, string ten, int maDM, int maNCC, string dvt,
            decimal giaNhap, decimal giaBan, int tonToiThieu, DateTime ngaySX, DateTime hanSD)
        {
            return DBHelper.ExecuteNonQuery(@"
                INSERT INTO HangHoa(MaSP,TenHH,MaDM,MaNCC,DonViTinh,GiaNhap,GiaBan,TonToiThieu,NgaySanXuat,HanSuDung)
                VALUES(@s,@t,@d,@n,@v,@gn,@gb,@tt,@nx,@hs)",
                new SqlParameter("@s", maSP), new SqlParameter("@t", ten),
                new SqlParameter("@d", maDM), new SqlParameter("@n", maNCC), new SqlParameter("@v", dvt),
                new SqlParameter("@gn", giaNhap), new SqlParameter("@gb", giaBan),
                new SqlParameter("@tt", tonToiThieu), 
                new SqlParameter("@nx", ngaySX), new SqlParameter("@hs", hanSD));
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
