using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public class frmTonKho : Form
    {
        DataGridView grid;
        public frmTonKho()
        {
            Text = "Tồn kho"; BackColor = Color.WhiteSmoke;
            var top = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = Color.White };
            top.Controls.Add(new Label { Text = "BẢNG TỒN KHO HIỆN TẠI", Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 12), AutoSize = true, ForeColor = Color.FromArgb(44, 62, 80) });
            grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White, RowHeadersVisible = false };
            Controls.Add(grid); Controls.Add(top);
            Load += (s,e) => {
                grid.DataSource = HangHoaDAL.GetTonKho();
                if (grid.Columns.Contains("MaHH")) grid.Columns["MaHH"].Visible = false;
                grid.CellFormatting += (a,b) => {
                    if (b.RowIndex < 0) return;
                    var st = grid.Rows[b.RowIndex].Cells["TrangThaiTon"].Value?.ToString();
                    if (st == "Cảnh báo") grid.Rows[b.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                };
            };
        }
    }
}
