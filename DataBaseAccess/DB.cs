namespace DataBaseAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<BaoCao> BaoCaos { get; set; }
        public virtual DbSet<ChiTietCumMay> ChiTietCumMays { get; set; }
        public virtual DbSet<ChiTietNhapKho> ChiTietNhapKhos { get; set; }
        public virtual DbSet<ChiTietSuKien> ChiTietSuKiens { get; set; }
        public virtual DbSet<ChiTietThanhToan> ChiTietThanhToans { get; set; }
        public virtual DbSet<ChucVuNhanVien> ChucVuNhanViens { get; set; }
        public virtual DbSet<CumMay> CumMays { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HuHaiCSVC> HuHaiCSVCs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiCumMay> LoaiCumMays { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
        public virtual DbSet<LoaiSuKien> LoaiSuKiens { get; set; }
        public virtual DbSet<LoaiTheThanhVien> LoaiTheThanhViens { get; set; }
        public virtual DbSet<LoaiThietBi> LoaiThietBis { get; set; }
        public virtual DbSet<LoaiTrangThai> LoaiTrangThais { get; set; }
        public virtual DbSet<Nguoi> Nguois { get; set; }
        public  List<Nguoi> ListNguois { get; set; }
        public virtual DbSet<NhaCungCapDichVu> NhaCungCapDichVus { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public  List<NhanVien> ListNhanViens { get; set; }
        public virtual DbSet<NhapKhoDichVu> NhapKhoDichVus { get; set; }
        public virtual DbSet<SuKien> SuKiens { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<TheThanhVien> TheThanhViens { get; set; }
        public virtual DbSet<ThietBi> ThietBis { get; set; }
        public virtual DbSet<ThongSoThietBi> ThongSoThietBis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVuNhanVien>()
                .Property(e => e.TenChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<ChucVuNhanVien>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.ChucVuNhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.TenDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.DonViTinh)
                .IsUnicode(false);

            modelBuilder.Entity<DichVu>()
                .Property(e => e.MoTa)
                .IsUnicode(false);


            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietNhapKhoes)
                .WithRequired(e => e.DichVu)
                .HasForeignKey(e => e.DichVuNhapKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.ChiTietThanhToans)
                .WithRequired(e => e.DichVu)
                .HasForeignKey(e => e.DichVuSuDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HuHaiCSVC>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.ThanhToans)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.TheThanhViens)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiCumMay>()
                .Property(e => e.TenLoaiCumMay)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiDichVu>()
                .Property(e => e.TenLoaiDichVu)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiDichVu>()
                .HasMany(e => e.DichVus)
                .WithRequired(e => e.LoaiDichVu1)
                .HasForeignKey(e => e.LoaiDichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDichVu>()
                .HasMany(e => e.NhaCungCapDichVus)
                .WithRequired(e => e.LoaiDichVu)
                .HasForeignKey(e => e.LoaiDichVuCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .Property(e => e.TenLoaiKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiKhachHang>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.LoaiKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSuKien>()
                .Property(e => e.TenLoaiSuKien)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTheThanhVien>()
                .Property(e => e.TenLoaiTheThanhVien)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTheThanhVien>()
                .HasMany(e => e.TheThanhViens)
                .WithRequired(e => e.LoaiTheThanhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiThietBi>()
                .Property(e => e.TenLoaiThietBi)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiTrangThai>()
                .Property(e => e.TenLoaiTrangThai)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.HoTen)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.Avartar)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .Property(e => e.TrangThai)
                .IsUnicode(false);

            modelBuilder.Entity<Nguoi>()
                .HasMany(e => e.KhachHangs)
                .WithRequired(e => e.Nguoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.Nguoi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCapDichVu>()
                .Property(e => e.TenNhaCungCap)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCapDichVu>()
                .Property(e => e.MSTNhaCungCap)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCapDichVu>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCapDichVu>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCapDichVu>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCapDichVu>()
                .HasMany(e => e.NhapKhoDichVus)
                .WithRequired(e => e.NhaCungCapDichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.NhapKhoDichVus)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ThanhToans)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhapKhoDichVu>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<NhapKhoDichVu>()
                .HasMany(e => e.ChiTietNhapKhoes)
                .WithRequired(e => e.NhapKhoDichVu)
                .HasForeignKey(e => e.MaNhapKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuKien>()
                .Property(e => e.TenSuKien)
                .IsUnicode(false);

            modelBuilder.Entity<SuKien>()
                .Property(e => e.MoTa)
                .IsUnicode(false);


            modelBuilder.Entity<ThanhToan>()
                .Property(e => e.HinhThucThanhToan)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhToan>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhToan>()
                .HasMany(e => e.ChiTietThanhToans)
                .WithRequired(e => e.ThanhToan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheThanhVien>()
                .Property(e => e.TinhTrangThe)
                .IsUnicode(false);

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.TenThietBi)
                .IsUnicode(false);

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<ThietBi>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<ThongSoThietBi>()
                .Property(e => e.NhaSanXuat)
                .IsUnicode(false);

            modelBuilder.Entity<ThongSoThietBi>()
                .Property(e => e.MoTa)
                .IsUnicode(false);
        }
    }
}
