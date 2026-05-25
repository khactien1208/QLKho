using QLKhoAChau.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhoAChau.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            lblUser.Text =
                $"👤 {Program.CurrentUser.HoTen}\n({Program.CurrentUser.VaiTro})";

            AddMenus();
        }

        private void AddMenus()
        {
            int y = 130;

            AddMenu("  Hàng hóa", y, BtnHangHoa_Click); y += 50;
            AddMenu("  Phiếu nhập", y, BtnPhieuNhap_Click); y += 50;
            AddMenu("  Phiếu xuất", y, BtnPhieuXuat_Click); y += 50;
            AddMenu("  Tồn kho", y, BtnTonKho_Click); y += 50;
            AddMenu("  Cảnh báo tồn thấp", y, BtnCanhBao_Click); y += 50;
            AddMenu("  Báo cáo N-X-T", y, BtnBaoCao_Click); y += 50;

            if (QLKhoAChau.Helpers.PhanQuyen.IsAdmin)
            {
                AddMenu("  Quản lý người dùng", y, BtnNguoiDung_Click);
                y += 50;
            }

            AddMenu("  Đăng xuất", y, BtnDangXuat_Click);
        }

        void AddMenu(string text, int top, EventHandler click)
        {
            var btn = new Button();

            btn.Text = text;
            btn.Top = top;
            btn.Left = 10;
            btn.Width = 200;
            btn.Height = 40;

            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;

            btn.BackColor = Color.FromArgb(44, 62, 80);

            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Font = new Font("Segoe UI", 10);

            btn.Cursor = Cursors.Hand;

            btn.FlatAppearance.BorderSize = 0;

            btn.MouseEnter += Menu_MouseEnter;
            btn.MouseLeave += Menu_MouseLeave;

            btn.Click += click;

            pnlSide.Controls.Add(btn);
        }

        private void Menu_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(52, 73, 94);
        }

        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(44, 62, 80);
        }

        private void BtnHangHoa_Click(object sender, EventArgs e)
        {
            Open(new frmHangHoa());
        }

        private void BtnPhieuNhap_Click(object sender, EventArgs e)
        {
            Open(new frmPhieuNhap());
        }

        private void BtnPhieuXuat_Click(object sender, EventArgs e)
        {
            Open(new frmPhieuXuat());
        }

        private void BtnTonKho_Click(object sender, EventArgs e)
        {
            Open(new frmTonKho());
        }

        private void BtnCanhBao_Click(object sender, EventArgs e)
        {
            Open(new frmCanhBao());
        }

        private void BtnBaoCao_Click(object sender, EventArgs e)
        {
            Open(new frmBaoCao());
        }

        private void BtnNguoiDung_Click(object sender, EventArgs e)
        {
            Open(new frmNguoiDung());
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void lblWarning_Click(object sender, EventArgs e)
        {
            Open(new frmCanhBao());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CheckCanhBao();
        }

        void Open(Form f)
        {
            pnlContent.Controls.Clear();

            pnlContent.Controls.Add(lblWarning);

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
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
                {
                    lblWarning.Text =
                        $"⚠️ Có {dt.Rows.Count} mặt hàng đang dưới ngưỡng tồn tối thiểu!";
                }
                else
                {
                    lblWarning.Text =
                        "✓ Tất cả hàng hóa đang ở mức tồn an toàn";
                }
            }
            catch
            {

            }
        }
    }
}
