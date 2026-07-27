using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    public class ChuyenNganhDAL
    {
        public List<ChuyenNganh> LayDanhSach()
        {
            using var db = new QuanLySinhVienDbContext();

            return db.ChuyenNganhs
                .Include(x => x.Khoa)
                .OrderBy(x => x.TenChuyenNganh)
                .ToList();
        }

        public ChuyenNganh? LayTheoId(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.ChuyenNganhs
                .Include(x => x.Khoa)
                .FirstOrDefault(x => x.Id == id);
        }

        public bool KiemTraTrungTen(string ten)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.ChuyenNganhs.Any(x => x.TenChuyenNganh == ten);
        }

        public bool KiemTraTrungTen(string ten, int idLoaiTru)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.ChuyenNganhs.Any(x =>
                x.TenChuyenNganh == ten &&
                x.Id != idLoaiTru);
        }

        public void ThemMoi(ChuyenNganh cn)
        {
            using var db = new QuanLySinhVienDbContext();

            db.ChuyenNganhs.Add(cn);
            db.SaveChanges();
        }

        public void CapNhat(ChuyenNganh cn)
        {
            using var db = new QuanLySinhVienDbContext();

            var cu = db.ChuyenNganhs.Find(cn.Id);

            if (cu == null)
                throw new Exception("Không tìm thấy chuyên ngành.");

            cu.TenChuyenNganh = cn.TenChuyenNganh;
            cu.KhoaId = cn.KhoaId;

            db.SaveChanges();
        }

        public void Xoa(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            var cn = db.ChuyenNganhs.Find(id);

            if (cn != null)
            {
                db.ChuyenNganhs.Remove(cn);
                db.SaveChanges();
            }
        }

        public int DemSoSinhVien(int chuyenNganhId)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens.Count(x => x.ChuyenNganhId == chuyenNganhId);
        }
    }
}