using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    public class SinhVienDAL
    {
        public List<SinhVien> LayDanhSach()
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens
                .Include(x => x.ChuyenNganh)
                .ThenInclude(x => x.Khoa)
                .OrderBy(x => x.MaSV)
                .ToList();
        }

        public SinhVien? LayTheoId(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens
                .Include(x => x.ChuyenNganh)
                .ThenInclude(x => x.Khoa)
                .FirstOrDefault(x => x.Id == id);
        }

        public bool KiemTraTrungMa(string maSV)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens.Any(s => s.MaSV == maSV);
        }

        public void ThemMoi(SinhVien sv)
        {
            using var db = new QuanLySinhVienDbContext();

            db.SinhViens.Add(sv);
            db.SaveChanges();
        }

        public void CapNhat(SinhVien sv)
        {
            using var db = new QuanLySinhVienDbContext();

            SinhVien? svTrongDb = db.SinhViens.FirstOrDefault(x => x.Id == sv.Id);

            if (svTrongDb == null)
                throw new Exception("Không tìm thấy sinh viên.");

            // Không sửa MaSV
            svTrongDb.HoTen = sv.HoTen;
            svTrongDb.NgaySinh = sv.NgaySinh;
            svTrongDb.GioiTinh = sv.GioiTinh;
            svTrongDb.ChuyenNganhId = sv.ChuyenNganhId;
            svTrongDb.DiemTB = sv.DiemTB;

            db.SaveChanges();
        }

        public void Xoa(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            SinhVien? sv = db.SinhViens.FirstOrDefault(x => x.Id == id);

            if (sv == null)
                throw new Exception("Không tìm thấy sinh viên.");

            db.SinhViens.Remove(sv);
            db.SaveChanges();
        }

        public List<SinhVien> TimKiem(
            string? tuKhoaVanBan,
            int? chuyenNganhId,
            double diemTu,
            double diemDen,
            bool baoGomChuaCoDiem)
        {
            using var db = new QuanLySinhVienDbContext();

            var truyVan = db.SinhViens
                .Include(x => x.ChuyenNganh)
                .ThenInclude(x => x.Khoa)
                .AsQueryable();

            // Tìm theo mã hoặc họ tên
            if (!string.IsNullOrWhiteSpace(tuKhoaVanBan))
            {
                string tuKhoa = tuKhoaVanBan.Trim().ToLower();

                truyVan = truyVan.Where(s =>
                    s.MaSV.ToLower().Contains(tuKhoa) ||
                    s.HoTen.ToLower().Contains(tuKhoa));
            }

            // Lọc theo chuyên ngành
            if (chuyenNganhId.HasValue)
            {
                truyVan = truyVan.Where(s =>
                    s.ChuyenNganhId == chuyenNganhId.Value);
            }

            // Đưa về bộ nhớ để xử lý nullable
            var ketQua = truyVan.ToList();

            ketQua = ketQua.Where(s =>
            {
                if (!s.DiemTB.HasValue)
                    return baoGomChuaCoDiem;

                return s.DiemTB.Value >= diemTu &&
                       s.DiemTB.Value <= diemDen;

            }).ToList();

            return ketQua;
        }

        public void DangKyChuyenNganh(string maSV, int chuyenNganhId)
        {
            using var db = new QuanLySinhVienDbContext();

            var sv = db.SinhViens
                .FirstOrDefault(x => x.MaSV == maSV);


            if (sv == null)
                throw new Exception("Không tìm thấy sinh viên");


            sv.ChuyenNganhId = chuyenNganhId;


            db.SaveChanges();
        }
    }
}