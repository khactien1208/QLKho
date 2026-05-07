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
    }
}