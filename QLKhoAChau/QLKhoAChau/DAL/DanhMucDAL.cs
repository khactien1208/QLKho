using System.Data;

namespace QLKhoAChau.DAL
{
    public static class DanhMucDAL
    {
        public static DataTable GetAll() =>
            DBHelper.ExecuteQuery("SELECT MaDM, TenDM FROM DanhMuc ORDER BY TenDM");
    }
}
