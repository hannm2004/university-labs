using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.BLL
{
    public class SinhVienBLL
    {
        private readonly SinhVienDAL sinhVienDAL = new SinhVienDAL();

        public List<SinhVien> LayDanhSach()
        {
            return sinhVienDAL.LayDanhSach();
        }

        public SinhVien? LayTheoId(int id)
        {
            return sinhVienDAL.LayTheoId(id);
        }

        private void ValidateDuLieu(
            string maSV,
            string hoTen,
            int chuyenNganhId,
            string? diemTBText,
            out double? diemTB)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new Exception("Mã sinh viên không được để trống.");

            if (string.IsNullOrWhiteSpace(hoTen))
                throw new Exception("Họ tên không được để trống.");

            if (chuyenNganhId <= 0)
                throw new Exception("Vui lòng chọn chuyên ngành.");

            diemTB = null;

            if (!string.IsNullOrWhiteSpace(diemTBText))
            {
                if (!double.TryParse(diemTBText, out double diem))
                    throw new Exception("Điểm trung bình không hợp lệ.");

                if (diem < 0 || diem > 10)
                    throw new Exception("Điểm trung bình phải từ 0 đến 10.");

                diemTB = diem;
            }
        }

        public void ThemMoi(
            string maSV,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            int chuyenNganhId,
            string? diemTBText)
        {
            ValidateDuLieu(
                maSV,
                hoTen,
                chuyenNganhId,
                diemTBText,
                out double? diemTB);

            maSV = maSV.Trim();

            if (sinhVienDAL.KiemTraTrungMa(maSV))
                throw new Exception("Mã sinh viên đã tồn tại.");

            SinhVien sv = new SinhVien
            {
                MaSV = maSV,
                HoTen = hoTen.Trim(),
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                ChuyenNganhId = chuyenNganhId,
                DiemTB = diemTB
            };

            sinhVienDAL.ThemMoi(sv);
        }

        public void CapNhat(
            int id,
            string maSV,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            int chuyenNganhId,
            string? diemTBText)
        {
            ValidateDuLieu(
                maSV,
                hoTen,
                chuyenNganhId,
                diemTBText,
                out double? diemTB);

            SinhVien sv = new SinhVien
            {
                Id = id,
                MaSV = maSV.Trim(),
                HoTen = hoTen.Trim(),
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                ChuyenNganhId = chuyenNganhId,
                DiemTB = diemTB
            };

            sinhVienDAL.CapNhat(sv);
        }

        public void Xoa(int id)
        {
            sinhVienDAL.Xoa(id);
        }

        public List<SinhVien> TimKiem(
            string? tuKhoa,
            int? chuyenNganhId,
            double diemTu,
            double diemDen,
            bool baoGomChuaCoDiem)
        {
            if (diemTu > diemDen)
                throw new Exception("Điểm từ không được lớn hơn điểm đến.");

            return sinhVienDAL.TimKiem(
                tuKhoa,
                chuyenNganhId,
                diemTu,
                diemDen,
                baoGomChuaCoDiem);
        }

        public void DangKyChuyenNganh(string maSV, int chuyenNganhId)
        {
            sinhVienDAL.DangKyChuyenNganh(
                maSV,
                chuyenNganhId
            );
        }
    }
}