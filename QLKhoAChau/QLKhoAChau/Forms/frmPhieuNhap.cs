using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLKhoAChau.DAL;
using QLKhoAChau.Helpers;

namespace QLKhoAChau.Forms
{
    public partial class frmPhieuNhap : Form
    {
        private DataTable dtTemp;

        public frmPhieuNhap()
        {
            InitializeComponent();

            // Phân quyền
            PhanQuyen.ApDungChiXem(btnAddItem, btnSave, btnNew, btnNewHH);
        }

        // =====================================================================
        //  LOAD
        // =====================================================================

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadGrid(string.Empty, null, null);
            NewPhieu();
            RdoSP_CheckedChanged(null, null);
        }

        private void LoadCombo()
        {
            cboNCC.DataSource    = PhieuNhapDAL.GetNCC();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember   = "MaNCC";

            cboHH.DataSource    = HangHoaDAL.GetDanhSachSP();
            cboHH.DisplayMember = "TenHienThi";
            cboHH.ValueMember   = "MaSP";

            cboDMMoi.DataSource    = DanhMucDAL.GetAll();
            cboDMMoi.DisplayMember = "TenDM";
            cboDMMoi.ValueMember   = "MaDM";

            cboNCCMoi.DataSource    = NhaCungCapDAL.GetAll();
            cboNCCMoi.DisplayMember = "TenNCC";
            cboNCCMoi.ValueMember   = "MaNCC";
        }

        private void LoadGrid(string kw, DateTime? tuNgay, DateTime? denNgay)
        {
            bool coFilter = !string.IsNullOrWhiteSpace(kw) || tuNgay.HasValue || denNgay.HasValue;
            gridPhieu.DataSource = coFilter
                ? PhieuNhapDAL.Filter(kw, tuNgay, denNgay)
                : PhieuNhapDAL.GetAll();

            if (gridPhieu.Columns.Contains("MaPN"))
                gridPhieu.Columns["MaPN"].Visible = false;

            if (gridPhieu.Columns.Contains("SoPhieu"))
            {
                gridPhieu.Columns["SoPhieu"].HeaderText  = "Số phiếu";
                gridPhieu.Columns["SoPhieu"].FillWeight  = 120;
            }
            if (gridPhieu.Columns.Contains("NgayNhap"))
            {
                gridPhieu.Columns["NgayNhap"].HeaderText                    = "Ngày nhập";
                gridPhieu.Columns["NgayNhap"].DefaultCellStyle.Format       = "dd/MM/yyyy HH:mm";
            }
            if (gridPhieu.Columns.Contains("TenNCC"))
            {
                gridPhieu.Columns["TenNCC"].HeaderText  = "Nhà cung cấp";
                gridPhieu.Columns["TenNCC"].FillWeight  = 180;
            }
            if (gridPhieu.Columns.Contains("NguoiNhap"))
                gridPhieu.Columns["NguoiNhap"].HeaderText = "Người nhập";

            if (gridPhieu.Columns.Contains("TongTien"))
            {
                gridPhieu.Columns["TongTien"].HeaderText              = "Tổng tiền";
                gridPhieu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }
        }

        // =====================================================================
        //  GRID EVENTS
        // =====================================================================

        private void gridPhieu_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPhieu.CurrentRow == null) return;
            if (gridPhieu.CurrentRow.Cells["MaPN"].Value == null) return;
            int id = (int)gridPhieu.CurrentRow.Cells["MaPN"].Value;
            gridChiTiet.DataSource = PhieuNhapDAL.GetChiTiet(id);
        }

        // =====================================================================
        //  TOOLBAR EVENTS
        // =====================================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid(txtSearch.Text, null, null);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadGrid(txtSearch.Text, null, null);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadGrid(
                txtSearch.Text,
                chkLoc.Checked ? (DateTime?)dtpTu.Value  : null,
                chkLoc.Checked ? (DateTime?)dtpDen.Value : null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            chkLoc.Checked = false;
            LoadGrid(string.Empty, null, null);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            XuatExcel(gridPhieu, "PhieuNhap");
        }

        // =====================================================================
        //  PHIẾU NHẬP
        // =====================================================================

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewPhieu();
        }

        private void NewPhieu()
        {
            txtSoPhieu.Text = PhieuNhapDAL.SinhSoPhieu();
            txtGhiChu.Clear();

            dtTemp = new DataTable();
            dtTemp.Columns.Add("MaSP",        typeof(string));
            dtTemp.Columns.Add("TenHH",        typeof(string));
            dtTemp.Columns.Add("MaDM",         typeof(int));
            dtTemp.Columns.Add("MaNCC",        typeof(int));
            dtTemp.Columns.Add("DonViTinh",    typeof(string));
            dtTemp.Columns.Add("GiaNhap",      typeof(decimal));
            dtTemp.Columns.Add("GiaBan",       typeof(decimal));
            dtTemp.Columns.Add("TonToiThieu",  typeof(int));
            dtTemp.Columns.Add("NgaySanXuat",  typeof(DateTime));
            dtTemp.Columns.Add("HanSuDung",    typeof(DateTime));
            dtTemp.Columns.Add("SoLuong",      typeof(int));
            dtTemp.Columns.Add("DonGia",       typeof(decimal));
            dtTemp.Columns.Add("ThanhTien",    typeof(decimal));

            gridTemp.DataSource = dtTemp;

            string[] hide = { "MaDM", "MaNCC", "GiaNhap", "GiaBan", "TonToiThieu" };
            foreach (string col in hide)
                if (gridTemp.Columns.Contains(col))
                    gridTemp.Columns[col].Visible = false;

            if (gridTemp.Columns.Contains("NgaySanXuat"))
                gridTemp.Columns["NgaySanXuat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (gridTemp.Columns.Contains("HanSuDung"))
                gridTemp.Columns["HanSuDung"].DefaultCellStyle.Format   = "dd/MM/yyyy";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count == 0)          { MessageBox.Show("Phiếu rỗng!"); return; }
            if (cboNCC.SelectedValue == null)     { MessageBox.Show("Chọn nhà cung cấp!"); return; }
            try
            {
                PhieuNhapDAL.Insert(txtSoPhieu.Text, (int)cboNCC.SelectedValue,
                    Program.CurrentUser.MaND, txtGhiChu.Text, dtTemp);
                MessageBox.Show("Lưu phiếu nhập thành công!");
                LoadGrid(string.Empty, null, null);
                LoadCombo();
                NewPhieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // =====================================================================
        //  THÊM DÒNG CHI TIẾT
        // =====================================================================

        private void RdoSP_CheckedChanged(object sender, EventArgs e)
        {
            if (pnlSpCu == null || pnlSpMoi == null) return;
            pnlSpCu.Visible  = rdoSPCu.Checked;
            pnlSpMoi.Visible = rdoSPMoi.Checked;
        }

        private void cboHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHH.SelectedItem is DataRowView drv)
            {
                var tbl = drv.Row.Table;
                if (tbl.Columns.Contains("GiaNhap") && drv["GiaNhap"] != DBNull.Value)
                    txtDonGia.Text = drv["GiaNhap"].ToString();
                else if (tbl.Columns.Contains("DonGia") && drv["DonGia"] != DBNull.Value)
                    txtDonGia.Text = drv["DonGia"].ToString();
                else
                    txtDonGia.Text = "0";
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSL.Text, out int sl) || sl <= 0)
            { MessageBox.Show("Số lượng không hợp lệ!"); return; }
            if (!decimal.TryParse(txtDonGia.Text, out decimal dg) || dg < 0)
            { MessageBox.Show("Đơn giá không hợp lệ!"); return; }
            if (!decimal.TryParse(txtGiaBanLo.Text, out decimal gb)) gb = 0;
            if (!int.TryParse(txtTonToiThieu.Text, out int ton)) ton = 0;
            if (dtpHSD.Value < dtpNSX.Value)
            { MessageBox.Show("Hạn SD phải sau Ngày SX!"); return; }

            string maSP, tenHH, dvt;
            int maDM, maNCC;

            if (rdoSPCu.Checked)
            {
                if (cboHH.SelectedItem == null) { MessageBox.Show("Chọn sản phẩm!"); return; }
                var drv = (DataRowView)cboHH.SelectedItem;
                maSP  = drv["MaSP"].ToString();
                string tenHienThi = drv["TenHienThi"].ToString();
                int idx = tenHienThi.IndexOf(" - ");
                tenHH = idx >= 0 ? tenHienThi.Substring(idx + 3) : tenHienThi;
                maDM  = drv["MaDM"] == DBNull.Value ? 1 : Convert.ToInt32(drv["MaDM"]);
                maNCC = drv["MaNCC"] == DBNull.Value ? (int)cboNCC.SelectedValue
                                                      : Convert.ToInt32(drv["MaNCC"]);
                dvt   = drv["DonViTinh"].ToString();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtMaSPMoi.Text)) { MessageBox.Show("Nhập Mã SP!"); return; }
                if (string.IsNullOrWhiteSpace(txtTenMoi.Text))  { MessageBox.Show("Nhập Tên hàng hóa!"); return; }
                if (cboDMMoi.SelectedValue == null)              { MessageBox.Show("Chọn danh mục!"); return; }
                maSP  = txtMaSPMoi.Text.Trim();
                tenHH = txtTenMoi.Text.Trim();
                maDM  = (int)cboDMMoi.SelectedValue;
                maNCC = cboNCCMoi.SelectedValue != null
                        ? (int)cboNCCMoi.SelectedValue
                        : (int)cboNCC.SelectedValue;
                dvt   = string.IsNullOrWhiteSpace(txtDVTMoi.Text) ? "Thùng" : txtDVTMoi.Text.Trim();
            }

            dtTemp.Rows.Add(
                maSP, tenHH, maDM, maNCC, dvt,
                dg, gb, ton,
                dtpNSX.Value, dtpHSD.Value,
                sl, dg, sl * dg);

            txtSL.Text          = "1";
            txtDonGia.Text      = "0";
            txtGiaBanLo.Text    = "0";
            txtTonToiThieu.Text = "10";
        }

        // =====================================================================
        //  THÊM HÀNG HÓA NHANH
        // =====================================================================

        private void btnNewHH_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmThemHangHoaNhanh())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(dlg.MaSPMoi))
                {
                    cboHH.DataSource    = HangHoaDAL.GetDanhSachSP();
                    cboHH.DisplayMember = "TenHienThi";
                    cboHH.ValueMember   = "MaSP";

                    cboNCC.DataSource    = PhieuNhapDAL.GetNCC();
                    cboNCC.DisplayMember = "TenNCC";
                    cboNCC.ValueMember   = "MaNCC";

                    if (dlg.MaNCCMoi > 0)
                        cboNCC.SelectedValue = dlg.MaNCCMoi;

                    var dt = (DataTable)cboHH.DataSource;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["MaSP"].ToString() == dlg.MaSPMoi)
                        { cboHH.SelectedIndex = i; break; }
                    }
                    rdoSPCu.Checked = true;
                }
            }
        }

        // =====================================================================
        //  XUẤT EXCEL
        // =====================================================================

        private void XuatExcel(DataGridView dgv, string tenFile)
        {
            if (dgv.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }

            var dlg = new SaveFileDialog
            {
                Filter   = "Excel CSV (*.csv)|*.csv",
                FileName = $"{tenFile}_{DateTime.Today:yyyyMMdd}.csv",
                Title    = "Lưu file Excel"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();

                var headers = new List<string>();
                foreach (DataGridViewColumn col in dgv.Columns)
                    if (col.Visible) headers.Add("\"" + col.HeaderText + "\"");
                sb.AppendLine(string.Join(",", headers));

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cells = new List<string>();
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (!col.Visible) continue;
                        string val = row.Cells[col.Index].FormattedValue?.ToString() ?? "";
                        cells.Add("\"" + val.Replace("\"", "\"\"") + "\"");
                    }
                    sb.AppendLine(string.Join(",", cells));
                }

                System.IO.File.WriteAllText(dlg.FileName, sb.ToString(),
                    new UTF8Encoding(true));

                if (MessageBox.Show("Xuất Excel thành công!\nMở file ngay?", "Thành công",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(dlg.FileName);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }
    }
}
