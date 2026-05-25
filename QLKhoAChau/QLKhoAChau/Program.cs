using System;
using System.Windows.Forms;
using QLKhoAChau.Forms;

namespace QLKhoAChau
{
    internal static class Program
    {
        public static Models.NguoiDung CurrentUser;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var login = new frmDangNhap1())
            {
                if (login.ShowDialog() == DialogResult.OK && CurrentUser != null)
                {
                    Application.Run(new frmMain());
                }
            }
        }
    }
}
