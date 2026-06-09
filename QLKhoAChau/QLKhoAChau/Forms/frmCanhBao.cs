using System.Data;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public partial class frmCanhBao : Form
    {
        public frmCanhBao()
        {
            InitializeComponent();
        }

        private void frmCanhBao_Load(object sender, System.EventArgs e)
        {
            DataTable dt = HangHoaDAL.GetCanhBao();
            grid.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                lblCount.Visible = false;
                MessageBox.Show(
                    "Không có hàng hóa nào tồn kho thấp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                lblCount.Visible = true;
                lblCount.Text    = $"Có {dt.Rows.Count} mặt hàng cần nhập thêm";
            }
        }
    }
}
