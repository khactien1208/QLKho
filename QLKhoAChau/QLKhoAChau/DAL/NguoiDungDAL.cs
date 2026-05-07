using System.Data;
using System.Data.SqlClient;
using QLKhoAChau.Models;

namespace QLKhoAChau.DAL
{
    public static class NguoiDungDAL
    {
        public static NguoiDung DangNhap(string user, string pass)
        {
            var dt = DBHelper.ExecuteQuery(
                "SELECT MaND,TenDangNhap,HoTen,VaiTro FROM NguoiDung WHERE TenDangNhap=@u AND MatKhau=@p AND TrangThai=1",
                new SqlParameter("@u", user), new SqlParameter("@p", pass));
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new NguoiDung
            {
                MaND = (int)r["MaND"],
                TenDangNhap = r["TenDangNhap"].ToString(),
                HoTen = r["HoTen"].ToString(),
                VaiTro = r["VaiTro"].ToString()
            };
        }

        public static DataTable GetAll()
        {
            return DBHelper.ExecuteQuery(
                "SELECT MaND, TenDangNhap, HoTen, VaiTro, TrangThai FROM NguoiDung ORDER BY MaND");
        }

        public static bool TonTai(string tenDangNhap)
        {
            var dt = DBHelper.ExecuteQuery(
                "SELECT 1 FROM NguoiDung WHERE TenDangNhap=@u",
                new SqlParameter("@u", tenDangNhap));
            return dt.Rows.Count > 0;
        }

        public static int Them(string tenDangNhap, string matKhau, string hoTen, string vaiTro)
        {
            return DBHelper.ExecuteNonQuery(
                "INSERT INTO NguoiDung(TenDangNhap,MatKhau,HoTen,VaiTro,TrangThai) VALUES(@u,@p,@h,@v,1)",
                new SqlParameter("@u", tenDangNhap),
                new SqlParameter("@p", matKhau),
                new SqlParameter("@h", hoTen),
                new SqlParameter("@v", vaiTro));
        }

        public static int CapNhat(int maND, string hoTen, string vaiTro, bool trangThai)
        {
            return DBHelper.ExecuteNonQuery(
                "UPDATE NguoiDung SET HoTen=@h, VaiTro=@v, TrangThai=@t WHERE MaND=@id",
                new SqlParameter("@h", hoTen),
                new SqlParameter("@v", vaiTro),
                new SqlParameter("@t", trangThai ? 1 : 0),
                new SqlParameter("@id", maND));
        }

        public static int DoiMatKhau(int maND, string matKhauMoi)
        {
            return DBHelper.ExecuteNonQuery(
                "UPDATE NguoiDung SET MatKhau=@p WHERE MaND=@id",
                new SqlParameter("@p", matKhauMoi),
                new SqlParameter("@id", maND));
        }

        public static int DoiMatKhauCoXacThuc(int maND, string matKhauCu, string matKhauMoi)
        {
            var dt = DBHelper.ExecuteQuery(
                "SELECT 1 FROM NguoiDung WHERE MaND=@id AND MatKhau=@p",
                new SqlParameter("@id", maND), new SqlParameter("@p", matKhauCu));
            if (dt.Rows.Count == 0) return 0;
            return DoiMatKhau(maND, matKhauMoi);
        }

        public static int Xoa(int maND)
        {
            return DBHelper.ExecuteNonQuery(
                "UPDATE NguoiDung SET TrangThai=0 WHERE MaND=@id",
                new SqlParameter("@id", maND));
        }
    }
}
