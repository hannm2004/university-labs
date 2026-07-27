using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.BLL
{
    public class ChuyenNganhBLL
    {
        private readonly ChuyenNganhDAL chuyenNganhDAL = new ChuyenNganhDAL();

        public List<ChuyenNganh> LayDanhSach()
        {
            return chuyenNganhDAL.LayDanhSach();
        }

        public ChuyenNganh? LayTheoId(int id)
        {
            return chuyenNganhDAL.LayTheoId(id);
        }

        private void ValidateDuLieu(string ten, int? khoaId)
        {
            if (string.IsNullOrWhiteSpace(ten))
                throw new Exception("Tên chuyên ngành không được để trống.");

            if (khoaId == null || khoaId <= 0)
                throw new Exception("Vui lòng chọn khoa.");
        }

        public void ThemMoi(string ten, int? khoaId)
        {
            ValidateDuLieu(ten, khoaId);

            ten = ten.Trim();

            if (chuyenNganhDAL.KiemTraTrungTen(ten))
                throw new Exception("Tên chuyên ngành đã tồn tại.");

            ChuyenNganh cn = new ChuyenNganh
            {
                TenChuyenNganh = ten,
                KhoaId = khoaId
            };

            chuyenNganhDAL.ThemMoi(cn);
        }

        public void CapNhat(int id, string ten, int? khoaId)
        {
            ValidateDuLieu(ten, khoaId);

            ten = ten.Trim();

            if (chuyenNganhDAL.KiemTraTrungTen(ten, id))
                throw new Exception("Tên chuyên ngành đã tồn tại.");

            ChuyenNganh cn = new ChuyenNganh
            {
                Id = id,
                TenChuyenNganh = ten,
                KhoaId = khoaId
            };

            chuyenNganhDAL.CapNhat(cn);
        }

        public void Xoa(int id)
        {
            int soSinhVien = chuyenNganhDAL.DemSoSinhVien(id);

            if (soSinhVien > 0)
            {
                throw new Exception(
                    $"Không thể xóa vì còn {soSinhVien} sinh viên thuộc chuyên ngành này.");
            }

            chuyenNganhDAL.Xoa(id);
        }
    }
}