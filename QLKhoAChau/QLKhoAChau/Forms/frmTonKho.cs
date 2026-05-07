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
            grid = new DataGridView { 
                Dock = DockStyle.Fill,

                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,

                MultiSelect = false,

                SelectionMode = DataGridViewSelectionMode.FullRowSelect,

                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,

                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,

                RowHeadersVisible = false,

                EnableHeadersVisualStyles = false,

                GridColor = Color.FromArgb(230, 230, 230),

                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,

                Font = new Font("Segoe UI", 10),

                RowTemplate = { Height = 32 },

                ColumnHeadersHeight = 40,
                ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            };
            // ===== HEADER =====

            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 73, 94);

            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            grid.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);


            // ===== DÒNG =====

            grid.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            grid.DefaultCellStyle.SelectionForeColor =
                Color.White;

            grid.DefaultCellStyle.Padding =
                new Padding(3);


            // ===== XEN KẼ MÀU =====

            grid.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            grid.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlGrid.Controls.Add(grid);

            Controls.Add(pnlGrid); 
            Controls.Add(top);
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
