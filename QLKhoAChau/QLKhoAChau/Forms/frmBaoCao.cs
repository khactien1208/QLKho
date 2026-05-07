using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public class frmBaoCao : Form
    {
        DataGridView grid;
        public frmBaoCao()
        {
            Text = "Báo cáo Nhập-Xuất-Tồn"; BackColor = Color.WhiteSmoke;
            var top = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.White };
            top.Controls.Add(new Label { Text = "BÁO CÁO NHẬP - XUẤT - TỒN", Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 12), AutoSize = true, ForeColor = Color.FromArgb(44, 62, 80) });
            grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White, RowHeadersVisible = false };
            Controls.Add(grid); Controls.Add(top);
            Load += (s,e) => {
                grid.DataSource = HangHoaDAL.GetTonKho();
                if (grid.Columns.Contains("MaHH")) grid.Columns["MaHH"].Visible = false;
            };
        }
    }
}
