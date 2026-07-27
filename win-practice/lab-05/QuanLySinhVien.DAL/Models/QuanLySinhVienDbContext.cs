using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-PN800PJP;Database=Lab04_QuanLySV;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
