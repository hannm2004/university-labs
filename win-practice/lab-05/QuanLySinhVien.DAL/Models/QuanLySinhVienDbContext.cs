using Microsoft.EntityFrameworkCore;

namespace QuanLySinhVien.DAL.Models
{
    public class QuanLySinhVienDbContext : DbContext
    {
        public DbSet<SinhVien> SinhViens { get; set; } = null!;
        public DbSet<Khoa> Khoas { get; set; } = null!;
        public DbSet<ChuyenNganh> ChuyenNganhs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LAPTOP-PN800PJP;Database=Lab04_QuanLySV;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ChuyenNganh>()
                .HasOne(cn => cn.Khoa)
                .WithMany(k => k.ChuyenNganhs)
                .HasForeignKey(cn => cn.KhoaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SinhVien>()
                .HasOne(sv => sv.ChuyenNganh)
                .WithMany(cn => cn.SinhViens)
                .HasForeignKey(sv => sv.ChuyenNganhId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}