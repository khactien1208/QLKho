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
    }
}
