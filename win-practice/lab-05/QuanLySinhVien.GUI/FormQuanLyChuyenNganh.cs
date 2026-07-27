using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormQuanLyChuyenNganh: Form
    {
        private readonly ChuyenNganhBLL chuyenNganhBLL = new();
        private readonly KhoaBLL khoaBLL = new();

        private int? idDangSua = null;
        public FormQuanLyChuyenNganh()
        {
            InitializeComponent();
        }
        private void FormQuanLyChuyenNganh_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            LoadChuyenNganh();
            LamMoiForm();
        }

        private void LoadKhoa()
        {
            cboKhoa.DataSource = khoaBLL.LayDanhSach();
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "Id";
            cboKhoa.SelectedIndex = -1;
        }

        private void LoadChuyenNganh()
        {
            var ds = chuyenNganhBLL.LayDanhSach();

            dgvChuyenNganh.DataSource = null;
            dgvChuyenNganh.DataSource = ds;

            lblTongSo.Text = $"Tổng số chuyên ngành: {ds.Count}";
        }

        private void LamMoiForm()
        {
            txtTenChuyenNganh.Clear();

            cboKhoa.SelectedIndex = -1;

            idDangSua = null;

            dgvChuyenNganh.ClearSelection();

            txtTenChuyenNganh.Focus();
        }

        private void dgvChuyenNganh_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ChuyenNganh cn =
                dgvChuyenNganh.Rows[e.RowIndex].DataBoundItem as ChuyenNganh;

            if (cn == null)
                return;

            idDangSua = cn.Id;

            txtTenChuyenNganh.Text = cn.TenChuyenNganh;

            cboKhoa.SelectedValue = cn.KhoaId;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                chuyenNganhBLL.ThemMoi(
                    txtTenChuyenNganh.Text,
                    (int?)cboKhoa.SelectedValue);

                MessageBox.Show(
                    "Thêm thành công!",
                    "Thông báo");

                LoadChuyenNganh();

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Chọn chuyên ngành.");
                return;
            }

            try
            {
                chuyenNganhBLL.CapNhat(
                    idDangSua.Value,
                    txtTenChuyenNganh.Text,
                    (int?)cboKhoa.SelectedValue);

                MessageBox.Show("Cập nhật thành công.");

                LoadChuyenNganh();

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Chọn chuyên ngành.");
                return;
            }

            if (MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                return;
            }

            try
            {
                chuyenNganhBLL.Xoa(idDangSua.Value);

                MessageBox.Show("Đã xóa.");

                LoadChuyenNganh();

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }
    }
}
