using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, System.EventArgs e)
        {
            grid.DataSource = HangHoaDAL.GetTonKho();

            if (grid.Columns.Contains("MaHH"))
                grid.Columns["MaHH"].Visible = false;
        }
    }
}
