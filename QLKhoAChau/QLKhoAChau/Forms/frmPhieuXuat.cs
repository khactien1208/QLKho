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
    public partial class frmPhieuXuat : Form
    {
        private DataTable dtTemp;

        public frmPhieuXuat()
        {
            InitializeComponent();

            // Phân quyền
            PhanQuyen.ApDungChiXem(btnAddItem, btnSave, btnNew, btnXuatHuy);
        }

        // =====================================================================
        //  LOAD
        // =====================================================================

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadGrid(string.Empty, null, null, string.Empty);
            NewPhieu();
        }

        private void LoadCombo()
        {
            cboKH.DataSource    = PhieuXuatDAL.GetKH();
            cboKH.DisplayMember = "TenKH";
            cboKH.ValueMember   = "MaKH";

            cboHH.DataSource    = HangHoaDAL.GetLoForXuatCombo();
            cboHH.DisplayMember = "TenHienThi";
            cboHH.ValueMember   = "MaHH";
        }

        private void LoadGrid(string kw = "", DateTime? tuNgay = null,
                              DateTime? denNgay = null, string loaiPhieu = "")
        {
            bool coFilter = !string.IsNullOrWhiteSpace(kw)
                         || tuNgay.HasValue
                         || denNgay.HasValue
                         || !string.IsNullOrWhiteSpace(loaiPhieu);

            gridPhieu.DataSource = coFilter
                ? PhieuXuatDAL.Filter(kw, tuNgay, denNgay, loaiPhieu)
                : PhieuXuatDAL.GetAll();

            if (gridPhieu.Columns.Contains("MaPX"))
                gridPhieu.Columns["MaPX"].Visible = false;

            if (gridPhieu.Columns.Contains("SoPhieu"))
            {
                gridPhieu.Columns["SoPhieu"].HeaderText = "Số phiếu";
                gridPhieu.Columns["SoPhieu"].FillWeight = 120;
            }
            if (gridPhieu.Columns.Contains("NgayXuat"))
            {
                gridPhieu.Columns["NgayXuat"].HeaderText                  = "Ngày xuất";
                gridPhieu.Columns["NgayXuat"].DefaultCellStyle.Format     = "dd/MM/yyyy HH:mm";
            }
            if (gridPhieu.Columns.Contains("TenKH"))
            {
                gridPhieu.Columns["TenKH"].HeaderText = "Khách hàng";
                gridPhieu.Columns["TenKH"].FillWeight = 180;
            }
            if (gridPhieu.Columns.Contains("NguoiXuat"))
                gridPhieu.Columns["NguoiXuat"].HeaderText = "Người xuất";

            if (gridPhieu.Columns.Contains("LoaiPhieu"))
                gridPhieu.Columns["LoaiPhieu"].HeaderText = "Loại phiếu";

            if (gridPhieu.Columns.Contains("TongTien"))
            {
                gridPhieu.Columns["TongTien"].HeaderText              = "Tổng tiền";
                gridPhieu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            }

            // Tô màu dòng XuatHuy
            foreach (DataGridViewRow row in gridPhieu.Rows)
                if (row.Cells["LoaiPhieu"]?.Value?.ToString() == "XuatHuy")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
        }

        // =====================================================================
        //  GRID EVENTS
        // =====================================================================

        private void gridPhieu_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPhieu.CurrentRow == null ||
                gridPhieu.CurrentRow.Cells["MaPX"].Value == null) return;

            int id = (int)gridPhieu.CurrentRow.Cells["MaPX"].Value;
            gridChiTiet.DataSource = PhieuXuatDAL.GetChiTiet(id);
        }

        // =====================================================================
        //  TOOLBAR EVENTS
        // =====================================================================

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid(txtSearch.Text, null, null, string.Empty);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadGrid(txtSearch.Text, null, null, string.Empty);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string loai = cboLoai.SelectedIndex == 0
                ? string.Empty
                : cboLoai.SelectedItem.ToString();

            LoadGrid(
                txtSearch.Text,
                chkLoc.Checked ? (DateTime?)dtpTu.Value  : null,
                chkLoc.Checked ? (DateTime?)dtpDen.Value : null,
                loai);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            chkLoc.Checked        = false;
            cboLoai.SelectedIndex = 0;
            LoadGrid(string.Empty, null, null, string.Empty);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            XuatExcel(gridPhieu, "PhieuXuat");
        }

        // =====================================================================
        //  PHIẾU XUẤT
        // =====================================================================

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewPhieu();
        }

        private void NewPhieu()
        {
            txtSoPhieu.Text    = PhieuXuatDAL.SinhSoPhieu();
            txtGhiChu.Clear();
            lblFIFO.Text       = string.Empty;
            btnXuatHuy.Visible = false;
            btnSave.Enabled    = true;

            dtTemp = new DataTable();
            dtTemp.Columns.Add("MaHH",      typeof(int));
            dtTemp.Columns.Add("TenHH");
            dtTemp.Columns.Add("HanSuDung", typeof(DateTime));
            dtTemp.Columns.Add("SoLuong",   typeof(int));
            dtTemp.Columns.Add("DonGia",    typeof(decimal));
            dtTemp.Columns.Add("ThanhTien", typeof(decimal));

            gridTemp.DataSource = dtTemp;

            if (gridTemp.Columns.Contains("MaHH"))
                gridTemp.Columns["MaHH"].Visible = false;
            if (gridTemp.Columns.Contains("HanSuDung"))
                gridTemp.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LuuPhieu("XuatBan");
        }

        private void btnXuatHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Xác nhận XUẤT HỦY lô hàng hết hạn?\nTồn kho sẽ bị trừ và lô sẽ bị đánh dấu Hủy.",
                    "Xác nhận xuất hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (dtTemp.Rows.Count == 0) btnAddItem_Click(sender, e);
            if (dtTemp.Rows.Count == 0) return;

            txtSoPhieu.Text = PhieuXuatDAL.SinhSoPhieuHuy();
            LuuPhieu("XuatHuy");
        }

        private void LuuPhieu(string loaiXuat)
        {
            if (dtTemp.Rows.Count == 0)       { MessageBox.Show("Phiếu rỗng!"); return; }
            if (cboKH.SelectedValue == null)  { MessageBox.Show("Chọn khách hàng!"); return; }
            try
            {
                PhieuXuatDAL.Insert(txtSoPhieu.Text, (int)cboKH.SelectedValue,
                    Program.CurrentUser.MaND, txtGhiChu.Text, dtTemp, loaiXuat);
                MessageBox.Show($"Lưu phiếu xuất {loaiXuat} thành công!");
                LoadGrid();
                LoadCombo();
                NewPhieu();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // =====================================================================
        //  THÊM DÒNG CHI TIẾT
        // =====================================================================

        private void cboHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHH.SelectedItem == null) return;
            var drv = (DataRowView)cboHH.SelectedItem;

            txtDonGia.Text = drv["GiaBan"].ToString();

            bool hetHan = false;
            DateTime hsd = DateTime.MaxValue;
            if (drv["HanSuDung"] != DBNull.Value)
            {
                hsd    = Convert.ToDateTime(drv["HanSuDung"]);
                hetHan = hsd < DateTime.Today;
            }

            string maSP = drv["MaSP"].ToString();

            // Gợi ý lô FIFO
            DataTable fifo = HangHoaDAL.GetLoFIFOByMaSP(maSP);
            if (fifo.Rows.Count > 0)
            {
                int fifoId = Convert.ToInt32(fifo.Rows[0]["MaHH"]);
                DateTime fifoHsd = fifo.Rows[0]["HanSuDung"] == DBNull.Value
                    ? DateTime.MaxValue
                    : Convert.ToDateTime(fifo.Rows[0]["HanSuDung"]);
                int selectedId = drv["MaHH"] == DBNull.Value ? 0 : Convert.ToInt32(drv["MaHH"]);

                if (selectedId != fifoId)
                {
                    lblFIFO.Text      = $"⚠ Nên xuất lô ID {fifoId} trước (HSD: {fifoHsd:dd/MM/yyyy})";
                    lblFIFO.ForeColor = Color.FromArgb(230, 126, 34);
                }
                else
                {
                    lblFIFO.Text      = "✔ Đây là lô nên xuất trước (HSD sớm nhất)";
                    lblFIFO.ForeColor = Color.FromArgb(39, 174, 96);
                }
            }
            else
            {
                lblFIFO.Text = string.Empty;
            }

            // Xử lý lô hết hạn
            if (hetHan)
            {
                btnXuatHuy.Visible = true;
                btnSave.Enabled    = false;
                lblFIFO.Text       = $"🚫 Lô này đã HẾT HẠN ({hsd:dd/MM/yyyy}) — chỉ được Xuất Hủy!";
                lblFIFO.ForeColor  = Color.Red;
            }
            else
            {
                btnXuatHuy.Visible = false;
                btnSave.Enabled    = true;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cboHH.SelectedValue == null)
            { MessageBox.Show("Chọn lô hàng!"); return; }
            if (!int.TryParse(txtSL.Text, out int sl) || sl <= 0)
            { MessageBox.Show("SL không hợp lệ"); return; }
            if (!decimal.TryParse(txtDonGia.Text, out decimal dg) || dg < 0)
            { MessageBox.Show("Đơn giá không hợp lệ"); return; }

            var drv  = (DataRowView)cboHH.SelectedItem;
            int ton  = Convert.ToInt32(drv["TonKho"]);
            int maHH = Convert.ToInt32(drv["MaHH"]);

            if (sl > ton) { MessageBox.Show($"Tồn kho lô này chỉ còn {ton}!"); return; }

            DateTime hsd = drv["HanSuDung"] == DBNull.Value
                ? DateTime.MaxValue
                : Convert.ToDateTime(drv["HanSuDung"]);

            string tenHienThi = drv["TenHienThi"].ToString();
            string tenHH      = tenHienThi;
            var parts = tenHienThi.Split(new string[] { " - " }, StringSplitOptions.None);
            if (parts.Length >= 3) tenHH = parts[2];

            dtTemp.Rows.Add(maHH, tenHH, hsd, sl, dg, sl * dg);
        }

        // =====================================================================
        //  THÊM KHÁCH HÀNG NHANH
        // =====================================================================

        private void btnNewKH_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmThemKhachHang())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK && dlg.MaKHMoi > 0)
                {
                    cboKH.DataSource    = PhieuXuatDAL.GetKH();
                    cboKH.DisplayMember = "TenKH";
                    cboKH.ValueMember   = "MaKH";
                    cboKH.SelectedValue = dlg.MaKHMoi;
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
