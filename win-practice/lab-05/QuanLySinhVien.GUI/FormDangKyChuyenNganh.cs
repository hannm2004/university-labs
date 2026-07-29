using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormDangKyChuyenNganh : Form
    {
        private readonly SinhVienBLL sinhVienBLL = new();
        private readonly KhoaBLL khoaBLL = new();
        private readonly ChuyenNganhBLL chuyenNganhBLL = new();


        public FormDangKyChuyenNganh()
        {
            InitializeComponent();
        }


        private void FormDangKyChuyenNganh_Load(object sender, EventArgs e)
        {
            LoadSinhVien();
            LoadKhoa();

            cboChuyenNganh.DataSource = null;
        }


        // Load danh sách sinh viên
        private void LoadSinhVien()
        {
            var ds = sinhVienBLL.LayDanhSach();

            cboSinhVien.DataSource = ds;

            cboSinhVien.DisplayMember = "HoTen";

            cboSinhVien.ValueMember = "MaSV";

            cboSinhVien.SelectedIndex = -1;
        }



        // Load danh sách khoa
        private void LoadKhoa()
        {
            var ds = khoaBLL.LayDanhSach();

            cboKhoa.DataSource = ds;

            cboKhoa.DisplayMember = "TenKhoa";

            cboKhoa.ValueMember = "Id";

            cboKhoa.SelectedIndex = -1;
        }



        // Khi chọn khoa -> load chuyên ngành
        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedValue == null)
                return;


            if (cboKhoa.SelectedValue is int khoaId)
            {
                var ds = chuyenNganhBLL
                    .LayTheoKhoa(khoaId);


                cboChuyenNganh.DataSource = ds;

                cboChuyenNganh.DisplayMember =
                    "TenChuyenNganh";

                cboChuyenNganh.ValueMember =
                    "Id";

                cboChuyenNganh.SelectedIndex = -1;
            }
        }



        // Khi chọn sinh viên -> hiện chuyên ngành hiện tại
        private void cboSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedItem == null)
                return;


            SinhVien sv =
                cboSinhVien.SelectedItem as SinhVien;


            if (sv == null)
                return;


            if (sv.ChuyenNganh != null)
            {
                lblCurrentValue.Text =
                    sv.ChuyenNganh.TenChuyenNganh;
            }
            else
            {
                lblCurrentValue.Text =
                    "Chưa đăng ký";
            }
        }




        // Đăng ký chuyên ngành
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboSinhVien.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Vui lòng chọn sinh viên.");
                    return;
                }


                if (cboChuyenNganh.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Vui lòng chọn chuyên ngành.");
                    return;
                }


                string maSV =
                    cboSinhVien.SelectedValue.ToString();


                int chuyenNganhId =
                    (int)cboChuyenNganh.SelectedValue;



                sinhVienBLL.DangKyChuyenNganh(
                    maSV,
                    chuyenNganhId
                );


                MessageBox.Show(
                    "Đăng ký chuyên ngành thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                LoadSinhVien();


            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cboChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuyenNganh.SelectedItem == null)
                return;

            ChuyenNganh? cn = cboChuyenNganh.SelectedItem as ChuyenNganh;

            if (cn == null)
                return;

            // Hiển thị chuyên ngành đang chọn
            lblCurrentValue.Text = cn.TenChuyenNganh;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}