using System.Drawing;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public class frmCanhBao : Form
    {
        DataGridView grid;
        Label lblCount;
        public frmCanhBao()
        {
            Text = "Cảnh báo tồn thấp"; BackColor = Color.WhiteSmoke;
            var top = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = Color.FromArgb(231, 76, 60) };
            top.Controls.Add(new Label { Text = "⚠️  CẢNH BÁO TỒN KHO THẤP",
                Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.White,
                Location = new Point(15, 10), AutoSize = true });
            lblCount = new Label { Location = new Point(15, 45), AutoSize = true,
                Font = new Font("Segoe UI", 10), ForeColor = Color.White };
            top.Controls.Add(lblCount);
            grid = new DataGridView { Dock = DockStyle.Fill,

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
                var dt = HangHoaDAL.GetCanhBao();
                grid.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    lblCount.Visible = false;

                    MessageBox.Show(
                        "Không có hàng hóa nào tồn kho thấp.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    lblCount.Visible = true;

                    lblCount.Text =
                        $"Có {dt.Rows.Count} mặt hàng cần nhập thêm";
                }
            };
        }
    }
}
