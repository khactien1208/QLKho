using System.Drawing;
using System.Windows.Forms;

namespace QLKhoAChau.Forms
{
    partial class frmMain
    {
        private Panel pnlSide;
        private Panel pnlContent;

        private Label lblUser;
        private Label lblWarning;
        private Label lblBrand;

        private void InitializeComponent()
        {
            pnlSide = new Panel();
            pnlContent = new Panel();

            lblUser = new Label();
            lblWarning = new Label();
            lblBrand = new Label();

            // FORM
            Text = "Quản lý kho - Bánh kẹo Á Châu";

            WindowState = FormWindowState.Maximized;

            StartPosition = FormStartPosition.CenterScreen;

            BackColor = Color.WhiteSmoke;

            Load += frmMain_Load;

            // pnlSide
            pnlSide.Dock = DockStyle.Left;
            pnlSide.Width = 220;

            pnlSide.BackColor = Color.FromArgb(44, 62, 80);

            // pnlContent
            pnlContent.Dock = DockStyle.Fill;

            pnlContent.BackColor = Color.WhiteSmoke;

            // lblBrand
            lblBrand.Text = "BÁNH KẸO Á CHÂU";

            lblBrand.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);

            lblBrand.ForeColor = Color.White;

            lblBrand.Dock = DockStyle.Top;

            lblBrand.Height = 60;

            lblBrand.TextAlign =
                ContentAlignment.MiddleCenter;

            lblBrand.BackColor =
                Color.FromArgb(192, 57, 43);

            // lblUser
            lblUser.Dock = DockStyle.Top;

            lblUser.Height = 50;

            lblUser.ForeColor = Color.White;

            lblUser.Font = new Font("Segoe UI", 9);

            lblUser.TextAlign =
                ContentAlignment.MiddleCenter;

            // lblWarning
            lblWarning.Dock = DockStyle.Top;

            lblWarning.Height = 40;

            lblWarning.BackColor =
                Color.FromArgb(255, 243, 205);

            lblWarning.ForeColor =
                Color.FromArgb(133, 100, 4);

            lblWarning.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lblWarning.TextAlign =
                ContentAlignment.MiddleCenter;

            lblWarning.Padding = new Padding(5);

            lblWarning.Cursor = Cursors.Hand;

            lblWarning.Click += lblWarning_Click;

            // ADD CONTROL
            pnlSide.Controls.Add(lblUser);
            pnlSide.Controls.Add(lblBrand);

            pnlContent.Controls.Add(lblWarning);

            Controls.Add(pnlContent);
            Controls.Add(pnlSide);
        }
    }
}