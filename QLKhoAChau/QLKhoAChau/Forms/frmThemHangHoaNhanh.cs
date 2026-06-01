using System;
using System.Data;
using System.Windows.Forms;
using QLKhoAChau.DAL;

namespace QLKhoAChau.Forms
{
    /// <summary>
    /// Dialog nhập nhanh hàng hóa mới ngay trong màn hình phiếu nhập.
    /// </summary>
    internal partial class frmThemHangHoaNhanh : Form
    {
        public string MaSPMoi  { get; private set; }
        public int    MaNCCMoi { get; private set; }

        public frmThemHangHoaNhanh()
        {
            InitializeComponent();
        }

        private void frmThemHangHoaNhanh_Load(object sender, EventArgs e)
        {
            cboDM.DataSource    = DanhMucDAL.GetAll();
            cboDM.DisplayMember = "TenDM";
            cboDM.ValueMember   = "MaDM";

            cboNCC.DataSource    = NhaCungCapDAL.GetAll();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember   = "MaNCC";

        }

        // =====================================================================
        //  THÊM DANH MỤC NHANH
        // =====================================================================

        private void btnNewDM_Click(object sender, EventArgs e)
        {
            string tenDM = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên danh mục mới:", "Thêm danh mục");

            if (string.IsNullOrWhiteSpace(tenDM)) return;

            try
            {
                DanhMucDAL.Insert(tenDM);
                DataTable dt = DanhMucDAL.GetAll();
                cboDM.DataSource    = dt;
                cboDM.DisplayMember = "TenDM";
                cboDM.ValueMember   = "MaDM";

                foreach (DataRow row in dt.Rows)
                {
                    if (row["TenDM"].ToString() == tenDM)
                    { cboDM.SelectedValue = row["MaDM"]; break; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // =====================================================================
        //  THÊM NHÀ CUNG CẤP NHANH
        // =====================================================================

        private void btnNewNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên nhà cung cấp mới:", "Thêm nhà cung cấp");

            if (string.IsNullOrWhiteSpace(tenNCC)) return;

            try
            {
                NhaCungCapDAL.Insert(tenNCC, "", "", "");
                DataTable dt = NhaCungCapDAL.GetAll();
                cboNCC.DataSource    = dt;
                cboNCC.DisplayMember = "TenNCC";
                cboNCC.ValueMember   = "MaNCC";

                foreach (DataRow row in dt.Rows)
                {
                    if (row["TenNCC"].ToString() == tenNCC)
                    {
                        MaNCCMoi = Convert.ToInt32(row["MaNCC"]);
                        cboNCC.SelectedValue = MaNCCMoi;
                        break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // =====================================================================
        //  LƯU
        // =====================================================================

        //private void btnOK_Click(object sender, EventArgs e)
        //{
        //    if (cboDM.SelectedValue  == null)              { MessageBox.Show("Chọn danh mục");         return; }
        //    if (cboNCC.SelectedValue == null)              { MessageBox.Show("Chọn nhà cung cấp");     return; }

        //    try
        //    {
        //        HangHoaDAL.Insert(
    
        //            (int)cboDM.SelectedValue, (int)cboNCC.SelectedValue
        //        );

        //        DialogResult = DialogResult.OK;
        //        Close();
        //    }
        //    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        //}
    }
}
