using System.Data;
using System.Data.SqlClient;

namespace QLKhoAChau.DAL
{
    public static class NhaCungCapDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery(@"
                SELECT MaNCC, TenNCC 
                FROM NhaCungCap 
                ORDER BY TenNCC");

                public static int Insert(string ten, string dc, string dt, string email)
            {
                return DBHelper.ExecuteNonQuery(@"
                    INSERT INTO NhaCungCap
                    (TenNCC, DiaChi, DienThoai, Email)
                    VALUES
                    (@t,@d,@dt,@e)",
                    new SqlParameter("@t", ten),
                    new SqlParameter("@d", dc),
                    new SqlParameter("@dt", dt),
                    new SqlParameter("@e", email)
                );
            }
    }
}