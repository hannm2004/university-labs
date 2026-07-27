using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;
namespace QuanLySinhVien.DAL
{
    public class QuanLySinhVienDbContext : DbContext
    {
        public DbSet<SinhVien> SinhViens { get; set; } = null!;
        public DbSet<Khoa> Khoas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-PN800PJP;Database=Lab04_QuanLySV;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
