using Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DatabaseContext
{
    public class Lab34Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("Data Source=TUNGHACK\\SQLEXPRESS;Initial Catalog=Lab34;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GioHangChiTiet>().HasOne(c => c.SanPham).WithMany(c => c.gioHangChiTiets).HasForeignKey(c => c.SanPhamId).IsRequired();
            modelBuilder.Entity<GioHangChiTiet>().HasOne(c => c.KhachHang).WithMany(c => c.gioHangChiTiets).HasForeignKey(c => c.KhachHangId).IsRequired();
            modelBuilder.Entity<SanPham>().HasKey(c => c.Id);
            modelBuilder.Entity<KhachHang>().HasKey(c => c.Id);
            modelBuilder.Entity<GioHangChiTiet>().HasKey(c => new {c.SanPhamId,c.KhachHangId});
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
