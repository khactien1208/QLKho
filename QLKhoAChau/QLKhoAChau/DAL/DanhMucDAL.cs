using System.Data;
using System.Data.SqlClient;

namespace QLKhoAChau.DAL
{
    public static class DanhMucDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery("SELECT MaDM, TenDM FROM DanhMuc ORDER BY TenDM");

            public static int Insert(string tenDM)
        {
            return DBHelper.ExecuteNonQuery(
                "INSERT INTO DanhMuc(TenDM) VALUES(@t)",
                new SqlParameter("@t", tenDM)
            );
        }
    }
}
