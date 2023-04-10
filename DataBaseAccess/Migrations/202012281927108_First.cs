namespace DataBaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaoCao",
                c => new
                    {
                        MaBaoCao = c.Int(nullable: false, identity: true),
                        Thang = c.Int(nullable: false),
                        Nam = c.Int(nullable: false),
                        TongChi = c.Int(nullable: false),
                        TongThu = c.Int(nullable: false),
                        TongLoiNhuan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaBaoCao);
            
            CreateTable(
                "dbo.ChiTietCumMay",
                c => new
                    {
                        MaChiTietCumMay = c.Int(nullable: false, identity: true),
                        MaCumMay = c.Int(nullable: false),
                        MaThietBi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTietCumMay);
            
            CreateTable(
                "dbo.ChiTietNhapKho",
                c => new
                    {
                        MaChiTietNhapKho = c.Int(nullable: false, identity: true),
                        MaNhapKho = c.Int(nullable: false),
                        DichVuNhapKho = c.Int(nullable: false),
                        SoLuongNhap = c.Int(nullable: false),
                        ChiPhiNhap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTietNhapKho)
                .ForeignKey("dbo.DichVu", t => t.DichVuNhapKho)
                .ForeignKey("dbo.NhapKhoDichVu", t => t.MaNhapKho)
                .Index(t => t.MaNhapKho)
                .Index(t => t.DichVuNhapKho);
            
            CreateTable(
                "dbo.DichVu",
                c => new
                    {
                        MaDichVu = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(nullable: false, maxLength: 200, unicode: false),
                        LoaiDichVu = c.Int(nullable: false),
                        GiaKinhDoanh = c.Int(nullable: false),
                        DonViTinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MoTa = c.String(nullable: false, maxLength: 100, unicode: false),
                        SoLuongConLai = c.Int(nullable: false),
                        HinhAnh = c.Int(nullable: false),
                        NgayCapNhat = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.MaDichVu)
                .ForeignKey("dbo.LoaiDichVu", t => t.LoaiDichVu)
                .Index(t => t.LoaiDichVu);
            
            CreateTable(
                "dbo.ChiTietThanhToan",
                c => new
                    {
                        MaChiTietThanhToan = c.Int(nullable: false, identity: true),
                        MaThanhToan = c.Int(nullable: false),
                        DichVuSuDung = c.Int(nullable: false),
                        SoLuongSuDung = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTietThanhToan)
                .ForeignKey("dbo.ThanhToan", t => t.MaThanhToan)
                .ForeignKey("dbo.DichVu", t => t.DichVuSuDung)
                .Index(t => t.MaThanhToan)
                .Index(t => t.DichVuSuDung);
            
            CreateTable(
                "dbo.ThanhToan",
                c => new
                    {
                        MaThanhToan = c.Int(nullable: false, identity: true),
                        MaKhachHang = c.Int(nullable: false),
                        MaNhanVien = c.Int(nullable: false),
                        TongThanhToan = c.Int(nullable: false),
                        NgayThanhToan = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        HinhThucThanhToan = c.String(nullable: false, maxLength: 100, unicode: false),
                        GhiChu = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaThanhToan)
                .ForeignKey("dbo.NhanVien", t => t.MaNhanVien)
                .ForeignKey("dbo.KhachHang", t => t.MaKhachHang)
                .Index(t => t.MaKhachHang)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKhachHang = c.Int(nullable: false, identity: true),
                        MaNguoi = c.Int(nullable: false),
                        MaLoaiKhachHang = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhachHang)
                .ForeignKey("dbo.LoaiKhachHang", t => t.MaLoaiKhachHang)
                .ForeignKey("dbo.Nguoi", t => t.MaNguoi)
                .Index(t => t.MaNguoi)
                .Index(t => t.MaLoaiKhachHang);
            
            CreateTable(
                "dbo.LoaiKhachHang",
                c => new
                    {
                        MaLoaiKhachHang = c.Int(nullable: false, identity: true),
                        TenLoaiKhachHang = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiKhachHang);
            
            CreateTable(
                "dbo.Nguoi",
                c => new
                    {
                        MaNguoi = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 50, unicode: false),
                        DiaChi = c.String(nullable: false, maxLength: 100, unicode: false),
                        SoDienThoai = c.String(nullable: false, maxLength: 20, unicode: false),
                        CMND = c.String(maxLength: 20, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Username = c.String(nullable: false, maxLength: 20, unicode: false),
                        Password = c.String(nullable: false, maxLength: 20, unicode: false),
                        Avartar = c.String(nullable: false, maxLength: 50, unicode: false),
                        NgayTao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TrangThai = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaNguoi);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false, identity: true),
                        MaNguoi = c.Int(nullable: false),
                        MaChucVu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhanVien)
                .ForeignKey("dbo.ChucVuNhanVien", t => t.MaChucVu)
                .ForeignKey("dbo.Nguoi", t => t.MaNguoi)
                .Index(t => t.MaNguoi)
                .Index(t => t.MaChucVu);
            
            CreateTable(
                "dbo.ChucVuNhanVien",
                c => new
                    {
                        MaChucVu = c.Int(nullable: false, identity: true),
                        TenChucVu = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaChucVu);
            
            CreateTable(
                "dbo.NhapKhoDichVu",
                c => new
                    {
                        MaHoaDonNhap = c.Int(nullable: false, identity: true),
                        MaNhaCungCap = c.Int(nullable: false),
                        NgayNhapKho = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        TongHoaDonNhap = c.Int(nullable: false),
                        GhiChu = c.String(nullable: false, maxLength: 100, unicode: false),
                        MaNhanVien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHoaDonNhap)
                .ForeignKey("dbo.NhaCungCapDichVu", t => t.MaNhaCungCap)
                .ForeignKey("dbo.NhanVien", t => t.MaNhanVien)
                .Index(t => t.MaNhaCungCap)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.NhaCungCapDichVu",
                c => new
                    {
                        MaNhaCungCap = c.Int(nullable: false, identity: true),
                        TenNhaCungCap = c.String(nullable: false, maxLength: 100, unicode: false),
                        MSTNhaCungCap = c.String(nullable: false, maxLength: 100, unicode: false),
                        DiaChi = c.String(nullable: false, maxLength: 100, unicode: false),
                        SoDienThoai = c.String(nullable: false, maxLength: 20, unicode: false),
                        GhiChu = c.String(nullable: false, maxLength: 100, unicode: false),
                        LoaiDichVuCungCap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhaCungCap)
                .ForeignKey("dbo.LoaiDichVu", t => t.LoaiDichVuCungCap)
                .Index(t => t.LoaiDichVuCungCap);
            
            CreateTable(
                "dbo.LoaiDichVu",
                c => new
                    {
                        MaLoaiDichVu = c.Int(nullable: false, identity: true),
                        TenLoaiDichVu = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiDichVu);
            
            CreateTable(
                "dbo.TheThanhVien",
                c => new
                    {
                        MaTheThanhVien = c.Int(nullable: false, identity: true),
                        MaKhachHang = c.Int(nullable: false),
                        NgayKichHoat = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        MaLoaiTheThanhVien = c.Int(nullable: false),
                        TinhTrangThe = c.String(nullable: false, maxLength: 50, unicode: false),
                        CapBacThe = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaTheThanhVien)
                .ForeignKey("dbo.LoaiTheThanhVien", t => t.MaLoaiTheThanhVien)
                .ForeignKey("dbo.KhachHang", t => t.MaKhachHang)
                .Index(t => t.MaKhachHang)
                .Index(t => t.MaLoaiTheThanhVien);
            
            CreateTable(
                "dbo.LoaiTheThanhVien",
                c => new
                    {
                        MaLoaiTheThanhVien = c.Int(nullable: false, identity: true),
                        TenLoaiTheThanhVien = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiTheThanhVien);
            
            CreateTable(
                "dbo.ChiTietSuKien",
                c => new
                    {
                        MaChiTietSuKien = c.Int(nullable: false, identity: true),
                        MaSuKien = c.Int(nullable: false),
                        MaNhanVien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaChiTietSuKien);
            
            CreateTable(
                "dbo.CumMay",
                c => new
                    {
                        MaCumMay = c.Int(nullable: false, identity: true),
                        SoThuTu = c.Int(nullable: false),
                        LoaiCumMay = c.Int(nullable: false),
                        LoaiTrangThai = c.Int(nullable: false),
                        ChiPhiThue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCumMay);
            
            CreateTable(
                "dbo.HuHaiCSVC",
                c => new
                    {
                        MaHuHai = c.Int(nullable: false, identity: true),
                        ThietBiHuHai = c.Int(nullable: false),
                        MoTa = c.String(nullable: false, maxLength: 100, unicode: false),
                        NgayHuHai = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        TinhTrang = c.Int(nullable: false),
                        ChiPhiSuaChua = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaHuHai);
            
            CreateTable(
                "dbo.LoaiCumMay",
                c => new
                    {
                        MaLoaiCumMay = c.Int(nullable: false, identity: true),
                        TenLoaiCumMay = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiCumMay);
            
            CreateTable(
                "dbo.LoaiSuKien",
                c => new
                    {
                        MaLoaiSuKien = c.Int(nullable: false, identity: true),
                        TenLoaiSuKien = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiSuKien);
            
            CreateTable(
                "dbo.LoaiThietBi",
                c => new
                    {
                        MaLoaiThietBi = c.Int(nullable: false, identity: true),
                        TenLoaiThietBi = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiThietBi);
            
            CreateTable(
                "dbo.LoaiTrangThai",
                c => new
                    {
                        MaLoaiTrangThai = c.Int(nullable: false, identity: true),
                        TenLoaiTrangThai = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiTrangThai);
            
            CreateTable(
                "dbo.SuKien",
                c => new
                    {
                        MaSuKien = c.Int(nullable: false, identity: true),
                        TenSuKien = c.String(maxLength: 100, unicode: false),
                        NgayBatDau = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        NgayKetThuc = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        MoTa = c.String(nullable: false, maxLength: 200, unicode: false),
                        LoaiSuKien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSuKien);
            
            CreateTable(
                "dbo.ThietBi",
                c => new
                    {
                        MaThietBi = c.Int(nullable: false, identity: true),
                        TenThietBi = c.String(nullable: false, maxLength: 200, unicode: false),
                        MoTa = c.String(nullable: false, maxLength: 200, unicode: false),
                        HinhAnh = c.String(nullable: false, maxLength: 200, unicode: false),
                        LoaiThietBi = c.Int(nullable: false),
                        NgayCapNhat = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        TrangThai = c.Int(nullable: false),
                        MaThongSo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaThietBi);
            
            CreateTable(
                "dbo.ThongSoThietBi",
                c => new
                    {
                        MaThongSo = c.Int(nullable: false, identity: true),
                        NhaSanXuat = c.String(nullable: false, maxLength: 200, unicode: false),
                        NamGioiThieu = c.Int(nullable: false),
                        MoTa = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.MaThongSo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietThanhToan", "DichVuSuDung", "dbo.DichVu");
            DropForeignKey("dbo.TheThanhVien", "MaKhachHang", "dbo.KhachHang");
            DropForeignKey("dbo.TheThanhVien", "MaLoaiTheThanhVien", "dbo.LoaiTheThanhVien");
            DropForeignKey("dbo.ThanhToan", "MaKhachHang", "dbo.KhachHang");
            DropForeignKey("dbo.NhanVien", "MaNguoi", "dbo.Nguoi");
            DropForeignKey("dbo.ThanhToan", "MaNhanVien", "dbo.NhanVien");
            DropForeignKey("dbo.NhapKhoDichVu", "MaNhanVien", "dbo.NhanVien");
            DropForeignKey("dbo.NhapKhoDichVu", "MaNhaCungCap", "dbo.NhaCungCapDichVu");
            DropForeignKey("dbo.NhaCungCapDichVu", "LoaiDichVuCungCap", "dbo.LoaiDichVu");
            DropForeignKey("dbo.DichVu", "LoaiDichVu", "dbo.LoaiDichVu");
            DropForeignKey("dbo.ChiTietNhapKho", "MaNhapKho", "dbo.NhapKhoDichVu");
            DropForeignKey("dbo.NhanVien", "MaChucVu", "dbo.ChucVuNhanVien");
            DropForeignKey("dbo.KhachHang", "MaNguoi", "dbo.Nguoi");
            DropForeignKey("dbo.KhachHang", "MaLoaiKhachHang", "dbo.LoaiKhachHang");
            DropForeignKey("dbo.ChiTietThanhToan", "MaThanhToan", "dbo.ThanhToan");
            DropForeignKey("dbo.ChiTietNhapKho", "DichVuNhapKho", "dbo.DichVu");
            DropIndex("dbo.TheThanhVien", new[] { "MaLoaiTheThanhVien" });
            DropIndex("dbo.TheThanhVien", new[] { "MaKhachHang" });
            DropIndex("dbo.NhaCungCapDichVu", new[] { "LoaiDichVuCungCap" });
            DropIndex("dbo.NhapKhoDichVu", new[] { "MaNhanVien" });
            DropIndex("dbo.NhapKhoDichVu", new[] { "MaNhaCungCap" });
            DropIndex("dbo.NhanVien", new[] { "MaChucVu" });
            DropIndex("dbo.NhanVien", new[] { "MaNguoi" });
            DropIndex("dbo.KhachHang", new[] { "MaLoaiKhachHang" });
            DropIndex("dbo.KhachHang", new[] { "MaNguoi" });
            DropIndex("dbo.ThanhToan", new[] { "MaNhanVien" });
            DropIndex("dbo.ThanhToan", new[] { "MaKhachHang" });
            DropIndex("dbo.ChiTietThanhToan", new[] { "DichVuSuDung" });
            DropIndex("dbo.ChiTietThanhToan", new[] { "MaThanhToan" });
            DropIndex("dbo.DichVu", new[] { "LoaiDichVu" });
            DropIndex("dbo.ChiTietNhapKho", new[] { "DichVuNhapKho" });
            DropIndex("dbo.ChiTietNhapKho", new[] { "MaNhapKho" });
            DropTable("dbo.ThongSoThietBi");
            DropTable("dbo.ThietBi");
            DropTable("dbo.SuKien");
            DropTable("dbo.LoaiTrangThai");
            DropTable("dbo.LoaiThietBi");
            DropTable("dbo.LoaiSuKien");
            DropTable("dbo.LoaiCumMay");
            DropTable("dbo.HuHaiCSVC");
            DropTable("dbo.CumMay");
            DropTable("dbo.ChiTietSuKien");
            DropTable("dbo.LoaiTheThanhVien");
            DropTable("dbo.TheThanhVien");
            DropTable("dbo.LoaiDichVu");
            DropTable("dbo.NhaCungCapDichVu");
            DropTable("dbo.NhapKhoDichVu");
            DropTable("dbo.ChucVuNhanVien");
            DropTable("dbo.NhanVien");
            DropTable("dbo.Nguoi");
            DropTable("dbo.LoaiKhachHang");
            DropTable("dbo.KhachHang");
            DropTable("dbo.ThanhToan");
            DropTable("dbo.ChiTietThanhToan");
            DropTable("dbo.DichVu");
            DropTable("dbo.ChiTietNhapKho");
            DropTable("dbo.ChiTietCumMay");
            DropTable("dbo.BaoCao");
        }
    }
}
