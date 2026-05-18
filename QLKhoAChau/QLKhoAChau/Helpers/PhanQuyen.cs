using System.Windows.Forms;

namespace QLKhoAChau.Helpers
{
    public static class PhanQuyen
    {
        public static bool IsAdmin =>
            Program.CurrentUser != null &&
            string.Equals(Program.CurrentUser.VaiTro, "Admin", System.StringComparison.OrdinalIgnoreCase);

        public static bool IsNhanVien =>
            Program.CurrentUser != null &&
            string.Equals(Program.CurrentUser.VaiTro, "NhanVien", System.StringComparison.OrdinalIgnoreCase);

        //NhanVien chỉ được xem hàng hóa, không được chỉnh sửa/xóa.
        // Admin được toàn quyền. ThuKho mặc định vẫn được chỉnh sửa nghiệp vụ kho.
        public static bool CoQuyenChinhSua => !IsNhanVien;

        public static void ApDungChiXem(params Control[] controls)
        {
            if (CoQuyenChinhSua) return;
            foreach (var c in controls)
            {
                if (c == null) continue;
                c.Enabled = false;
            }
        }
    }
}
