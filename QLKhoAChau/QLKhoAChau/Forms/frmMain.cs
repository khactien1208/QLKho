using System;
using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public class frmMain : Form
    {
        Panel pnlSide, pnlContent;
        Label lblUser, lblWarning;

        public frmMain()
        {
            Text = "Quản lý kho - Bánh kẹo Á Châu";
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.WhiteSmoke;

            pnlSide = new Panel { Dock = DockStyle.Left, Width = 220, BackColor = Color.FromArgb(44, 62, 80) };
            pnlContent = new Panel { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };

            var lblBrand = new Label {
                Text = "BÁNH KẸO Á CHÂU",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White, Dock = DockStyle.Top, Height = 60,
                TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.FromArgb(192, 57, 43)
            };

            lblUser = new Label {
                Dock = DockStyle.Top, Height = 50, ForeColor = Color.White,
                Font = new Font("Segoe UI", 9), TextAlign = ContentAlignment.MiddleCenter,
                Text = $"👤 {Program.CurrentUser.HoTen}\n({Program.CurrentUser.VaiTro})"
            };

            pnlSide.Controls.Add(lblUser);
            pnlSide.Controls.Add(lblBrand);

            int y = 130;
            AddMenu("  Hàng hóa", y, () => Open(new frmHangHoa())); y += 50;
            AddMenu("  Phiếu nhập", y, () => Open(new frmPhieuNhap())); y += 50;
            AddMenu("  Phiếu xuất", y, () => Open(new frmPhieuXuat())); y += 50;
            AddMenu("  Tồn kho", y, () => Open(new frmTonKho())); y += 50;
            AddMenu("  Cảnh báo tồn thấp", y, () => Open(new frmCanhBao())); y += 50;
            AddMenu("  Báo cáo N-X-T", y, () => Open(new frmBaoCao())); y += 50;
            if (QLKhoAChau.Helpers.PhanQuyen.IsAdmin)
            {
                AddMenu("  Quản lý người dùng", y, () => Open(new frmNguoiDung())); y += 50;
            }
            AddMenu("  Đăng xuất", y, () => { Application.Restart(); });

            // Thanh cảnh báo
            lblWarning = new Label {
                Dock = DockStyle.Top, Height = 40,
                BackColor = Color.FromArgb(255, 243, 205), ForeColor = Color.FromArgb(133, 100, 4),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(5),
                Visible = true
            };
            pnlContent.Controls.Add(lblWarning);

            pnlContent.Controls.Add(new Label { Dock = DockStyle.Fill,
                Text = "Chào mừng đến với hệ thống quản lý kho Á Châu",
                Font = new Font("Segoe UI", 18), TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray });
            lblWarning.BringToFront();

            Controls.Add(pnlContent);
            Controls.Add(pnlSide);

            lblWarning.Cursor = Cursors.Hand;

            lblWarning.Click += (s,e) =>
            {
                Open(new frmCanhBao());
            };
            Load += (s,e) => CheckCanhBao();
        }

        void AddMenu(string text, int top, Action onClick)
        {
            var btn = new Button {
                Text = text, Top = top, Left = 10, Width = 200, Height = 40,
                FlatStyle = FlatStyle.Flat, ForeColor = Color.White,
                BackColor = Color.FromArgb(44, 62, 80),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10), Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s,e) => btn.BackColor = Color.FromArgb(52, 73, 94);
            btn.MouseLeave += (s,e) => btn.BackColor = Color.FromArgb(44, 62, 80);
            btn.Click += (s,e) => onClick();
            pnlSide.Controls.Add(btn);
        }

        void Open(Form f)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(lblWarning);

            f.TopLevel = false; f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(f);
            lblWarning.BringToFront();
            f.Show();
        }

        public void CheckCanhBao()
        {
            try
            {
                var dt = HangHoaDAL.GetCanhBao();
                if (dt.Rows.Count > 0)
                    lblWarning.Text = $"⚠️  Có {dt.Rows.Count} mặt hàng đang dưới ngưỡng tồn tối thiểu - cần nhập thêm!";
                else
                    lblWarning.Text = "✓ Tất cả hàng hóa đang ở mức tồn an toàn";
            }
            catch { }
        }
    }
}
