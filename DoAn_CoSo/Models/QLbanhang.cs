using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAn_CoSo.Models
{
    public partial class QLbanhang : DbContext
    {
        public QLbanhang()
            : base("name=QLbanhang")
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Loaisach> Loaisaches { get; set; }
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; }
        public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }
        public virtual DbSet<Phanquyen> Phanquyens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietdonhang>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Chitietdonhang>()
                .Property(e => e.Giatien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Loaisach>()
                .Property(e => e.Tenloai)
                .IsFixedLength();

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Dienthoai)
                .IsFixedLength();

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Nhaxuatban>()
                .Property(e => e.Tennxb)
                .IsFixedLength();

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Giatien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Chitietdonhang)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);
        }
    }
}
