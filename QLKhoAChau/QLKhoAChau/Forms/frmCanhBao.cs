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
            grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, BackgroundColor = Color.White, RowHeadersVisible = false };
            Controls.Add(grid); Controls.Add(top);
            Load += (s,e) => {
                var dt = HangHoaDAL.GetCanhBao();
                grid.DataSource = dt;
                lblCount.Text = $"Có {dt.Rows.Count} mặt hàng cần nhập thêm";
            };
        }
    }
}
