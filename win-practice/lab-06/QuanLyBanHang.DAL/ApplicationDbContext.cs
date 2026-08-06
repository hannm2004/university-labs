using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using QuanLyBanHang.DAL.Entities;
using System.Configuration;

namespace QuanLyBanHang.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=LAPTOP-PN800PJP;Database=QuanLyBanHangDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customer - Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order - OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product - OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // decimal
            modelBuilder.Entity<Product>()
                .Property(p => p.DonGia)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetail>()
                .Property(d => d.DonGiaLucBan)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.MaSP)
                .HasMaxLength(20);

            modelBuilder.Entity<Product>()
                .Property(p => p.TenSP)
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(c => c.HoTen)
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(c => c.SoDienThoai)
                .HasMaxLength(15);
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.MaSP)
                .IsUnique();
        }
    }
}