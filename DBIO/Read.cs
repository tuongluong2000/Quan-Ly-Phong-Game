
using DataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBIO
{
    public class Read
    {
        DB db = new DB();


        //chi tiết thông tin nhân viên 
        public List<NhanViens> ReadNhanViens()
        {
            var model = from a in db.NhanViens
                        join b in db.Nguois
                        on a.MaNguoi equals b.MaNguoi
                        where a.MaNguoi == b.MaNguoi

                        join c in db.ChucVuNhanViens
                        on a.MaChucVu equals c.MaChucVu
                        where a.MaChucVu == c.MaChucVu
                        select new NhanViens()
                        {
                            HoTen = b.HoTen,
                            MaNhanVien = a.MaNhanVien,
                            TenChucVu = c.TenChucVu,
                            DiaChi = b.DiaChi,
                            SoDienThoai = b.SoDienThoai,
                            Cmnd = b.CMND,
                            Email = b.Email,
                            Username = b.Username,
                            NgayTao = b.NgayTao,
                            TrangThai = b.TrangThai,
                            MaChucVu = c.MaChucVu,
                            MaNguoi = b.MaNguoi,
                        };
            return model.ToList();
        }

        // chi tiết thông tin khách hàng
        public List<KhachHangs> ReadKhachHangs()
        {
            var model = from a in db.KhachHangs
                        join b in db.Nguois
                        on a.MaNguoi equals b.MaNguoi
                        where a.MaNguoi == b.MaNguoi

                        join c in db.LoaiKhachHangs
                        on a.MaLoaiKhachHang equals c.MaLoaiKhachHang
                        where a.MaLoaiKhachHang == c.MaLoaiKhachHang

                        join d in db.TheThanhViens
                        on a.MaKhachHang equals d.MaKhachHang
                        where a.MaKhachHang == d.MaKhachHang

                        join e in db.LoaiTheThanhViens
                        on d.MaLoaiTheThanhVien equals e.MaLoaiTheThanhVien
                        where d.MaLoaiTheThanhVien == e.MaLoaiTheThanhVien

                        select new KhachHangs()
                        {
                            HoTen = b.HoTen,
                            MaKhachHang = a.MaKhachHang,
                            TenLoaiKhachHang= c.TenLoaiKhachHang,
                            DiaChi = b.DiaChi,
                            SoDienThoai = b.SoDienThoai,
                            Cmnd = b.CMND,
                            Email = b.Email,
                            NgayTao = b.NgayTao,
                            TrangThai = b.TrangThai,
                            MaLoaiKhachHang = c.MaLoaiKhachHang,
                            MaNguoi = b.MaNguoi,
                            MaTheThanhVien = d.MaTheThanhVien,
                            NgayKichHoat = d.NgayKichHoat,
                            MaLoaiTheThanhVien = d.MaLoaiTheThanhVien,
                            TinhTrangThe = d.TinhTrangThe,
                            CapBatThe = d.CapBacThe,
                            TenLoaiTheThanhVien = e.TenLoaiTheThanhVien,
                        };
            return model.ToList();
        }

        //chi tiết dịch vụ 
        public List<DichVus> ReadDichVus()
        {
            var model = from a in db.DichVus
                        join b in db.LoaiDichVus
                        on a.LoaiDichVu equals b.MaLoaiDichVu
                        where a.LoaiDichVu == b.MaLoaiDichVu

                        select new DichVus()
                        {
                            MaDichVu = a.MaDichVu,
                            TenDichVu = a.TenDichVu,
                            MaLoaiDichVu =a.LoaiDichVu,
                            GiaKinhDoanh = a.GiaKinhDoanh,
                            DonViTinh = a.DonViTinh,
                            MoTa = a.MoTa,
                            SoLuongConLai = a.SoLuongConLai,
                            HinhAnh = a.HinhAnh,
                            NgayCapNhat = a.NgayCapNhat,
                            TenLoaiDichVu = b.TenLoaiDichVu,
                        };
            return model.ToList();
        }

        //chi tiet thanh toan
        public List<ThanhToans> ReadThanhToans()
        {
            var model = from a in db.ThanhToans
                        join b in db.ChiTietThanhToans
                        on a.MaThanhToan equals b.MaThanhToan
                        where a.MaThanhToan == b.MaThanhToan

                        join c in db.DichVus
                        on b.DichVuSuDung equals c.MaDichVu
                        where b.DichVuSuDung == c.MaDichVu

                        join d in db.KhachHangs
                        on a.MaKhachHang equals d.MaKhachHang
                        where a.MaKhachHang == d.MaKhachHang

                        join n in db.Nguois
                        on d.MaNguoi equals n.MaNguoi
                        where d.MaNguoi == n.MaNguoi

                        join e in db.NhanViens
                        on a.MaNhanVien equals e.MaNhanVien
                        where a.MaNhanVien == e.MaNhanVien

                        select new ThanhToans()
                        {
                            MaThanhToan = a.MaThanhToan,
                            MaKhachHang = a.MaKhachHang,
                            MaNhanVien = a.MaNhanVien,
                            TongThanhToan = a.TongThanhToan,
                            HinhThucThanhToan = a.HinhThucThanhToan,
                            MaChiTietThanhToan = b.MaChiTietThanhToan,
                            MaDichVu = b.DichVuSuDung,
                            SoLuongSuDung = b.SoLuongSuDung,
                            GhiChu = a.GhiChu,
                            NgayThanhToan = a.NgayThanhToan,
                            TenDichVu = c.TenDichVu,
                            GiaKinhDoanh = c.GiaKinhDoanh,
                            SoLuongConLai = c.SoLuongConLai,
                            TenKhachHang = n.HoTen,
                            LoaiKhachHang = d.MaLoaiKhachHang,
                        };
            return model.ToList();
        }

        //chi tiết cụm máy 
        public List<CumMays> ReadCumMays()
        {
            var model = from cummay in db.CumMays
                        join loaicm in db.LoaiCumMays
                        on cummay.LoaiCumMay equals loaicm.MaLoaiCumMay
                        where cummay.LoaiCumMay == loaicm.MaLoaiCumMay

                        join loaitt in db.LoaiTrangThais
                        on cummay.LoaiTrangThai equals loaitt.MaLoaiTrangThai
                        where cummay.LoaiTrangThai == loaitt.MaLoaiTrangThai

                        join ctcm in db.ChiTietCumMays
                        on cummay.MaCumMay equals ctcm.MaCumMay
                        where cummay.MaCumMay ==ctcm.MaCumMay

                        join thietbi in db.ThietBis
                        on ctcm.MaThietBi equals thietbi.MaThietBi
                        where ctcm.MaThietBi ==thietbi.MaThietBi
                        
                        join loaitb in db.LoaiThietBis
                        on thietbi.LoaiThietBi equals loaitb.MaLoaiThietBi
                        where thietbi.LoaiThietBi == loaitb.MaLoaiThietBi

                        join tstb in db.ThongSoThietBis
                        on thietbi.MaThongSo equals tstb.MaThongSo
                        where thietbi.MaThongSo == tstb.MaThongSo

                        select new CumMays()
                        {
                            MaCumMay = cummay.MaCumMay,
                            SoThuTu = cummay.SoThuTu,
                            LoaiCumMay = cummay.LoaiCumMay,
                            LoaiTrangThai = cummay.LoaiTrangThai,
                            ChiPhiThue = cummay.ChiPhiThue,
                            TenLoaiCumMay = loaicm.TenLoaiCumMay,
                            TenLoaiTrangThai = loaitt.TenLoaiTrangThai,
                            MaChiTietCumMay = ctcm.MaChiTietCumMay,
                            MaThietBi = ctcm.MaThietBi,
                            TenThietBi = thietbi.TenThietBi,
                            MoTaThietBi = thietbi.MoTa,
                            HinhAnh = thietbi.HinhAnh,
                            LoaiThietBi = thietbi.LoaiThietBi,
                            TenLoaiThietBi = loaitb.TenLoaiThietBi,
                            NgayCapNhat = thietbi.NgayCapNhat,
                            TrangThaiThietBi = thietbi.TrangThai,
                            MaThongSo = thietbi.MaThongSo,
                            NhaSanXuat = tstb.NhaSanXuat,
                            NamGioiThieu = tstb.NamGioiThieu,
                            MoTaThongSo = tstb.MoTa,
                        };
            return model.ToList();
        }

        //chi tiet nhap kho 
        public List<NhapKhos> ReadNhapKhos()
        {
            var model = from nk in db.NhapKhoDichVus
                        join ctnk in db.ChiTietNhapKhos
                        on nk.MaHoaDonNhap equals ctnk.MaNhapKho
                        where nk.MaHoaDonNhap == ctnk.MaNhapKho

                        join dv in db.DichVus
                        on ctnk.DichVuNhapKho equals dv.MaDichVu
                        where ctnk.DichVuNhapKho == dv.MaDichVu

                        join ncc in db.NhaCungCapDichVus
                        on nk.MaNhaCungCap equals ncc.MaNhaCungCap
                        where nk.MaNhaCungCap == ncc.MaNhaCungCap

                        select new NhapKhos()
                        {
                            MaHoaDonNhapKho = nk.MaHoaDonNhap,
                            MaNhaCungCap = nk.MaNhaCungCap,
                            TongHoaDonNhap = nk.TongHoaDonNhap,
                            MaNhanVien = nk.MaNhanVien,
                            MaChiTietNhapKho = ctnk.MaChiTietNhapKho,
                            DichVuNhapKho = ctnk.DichVuNhapKho,
                            SoLuongNhap = ctnk.SoLuongNhap,
                            GhiChu = nk.GhiChu,
                            TenDichVu = dv.TenDichVu,
                            TenNhaCungCap = ncc.TenNhaCungCap,
                            ChiPhiNhap = ctnk.ChiPhiNhap,
                            NgayNhapKho = nk.NgayNhapKho,
                        };
            return model.ToList();
        }

        //Nguoi
        public List<Nguoi> ReadListNguoi()
        {
            string sql = "select * from Nguoi";
            return db.Database.SqlQuery<Nguoi>(sql).ToList();
        }

        public List<Nguoi> ReadNguoi(string column,string values)
        {
            string sql = "select * from Nguoi where "+ column +"=" +values;
            return db.Database.SqlQuery<Nguoi>(sql).ToList();
        }

        //Nhan vien
        public List<NhanVien> ReadListNhanVien()
        {
            string sql = "select * from NhanVien";
            return db.Database.SqlQuery<NhanVien>(sql).ToList();
        }

        public List<NhanVien> ReadNhanVien(string column, string values)
        {
            string sql = "select * from NhanVien where " + column + "=" + values;
            return db.Database.SqlQuery<NhanVien>(sql).ToList();
        }

        //Chuc vu Nhan Vien
        public List<ChucVuNhanVien> ReadListChucVuNhanVien()
        {
            string sql = "select * from ChucVuNhanVien";
            return db.Database.SqlQuery<ChucVuNhanVien>(sql).ToList();
        }

        public List<ChucVuNhanVien> ReadChucVuNhanVien(string column, string values)
        {
            string sql = "select * from ChucVuNhanVien where " + column + "=" + values;
            return db.Database.SqlQuery<ChucVuNhanVien>(sql).ToList();
        }

        //Khach Hang
        public List<KhachHang> ReadListKhachHang()
        {
            string sql = "select * from KhachHang";
            return db.Database.SqlQuery<KhachHang>(sql).ToList();
        }

        public List<KhachHang> ReadKhachHang(string column, string values)
        {
            string sql = "select * from KhachHang where " + column + "=" + values;
            return db.Database.SqlQuery<KhachHang>(sql).ToList();
        }

        //Loai Khach Hang
        public List<LoaiKhachHang> ReadListLoaiKhachHang()
        {
            string sql = "select * from LoaiKhachHang";
            return db.Database.SqlQuery<LoaiKhachHang>(sql).ToList();
        }

        public List<LoaiKhachHang> ReadLoaiKhachHang(string column, string values)
        {
            string sql = "select * from LoaiKhachHang where " + column + "=" + values;
            return db.Database.SqlQuery<LoaiKhachHang>(sql).ToList();
        }

        //The Thanh Vien
        public List<TheThanhVien> ReadListTheThanhVien()
        {
            string sql = "select * from TheThanhVien";
            return db.Database.SqlQuery<TheThanhVien>(sql).ToList();
        }

        public List<TheThanhVien> ReadTheThanhVien(string column, string values)
        {
            string sql = "select * from TheThanhVien where " + column + "=" + values;
            return db.Database.SqlQuery<TheThanhVien>(sql).ToList();
        }

        //Loai The Thanh Vien
        public List<LoaiTheThanhVien> ReadListLoaiTheThanhVien()
        {
            string sql = "select * from LoaiTheThanhVien";
            return db.Database.SqlQuery<LoaiTheThanhVien>(sql).ToList();
        }

        public List<LoaiTheThanhVien> ReadLoaiTheThanhVien(string column, string values)
        {
            string sql = "select * from LoaiTheThanhVien where " + column + "=" + values;
            return db.Database.SqlQuery<LoaiTheThanhVien>(sql).ToList();
        }

        //Thanh Toan
        public List<ThanhToan> ReadListThanhToan()
        {
            string sql = "select * from ThanhToan";
            return db.Database.SqlQuery<ThanhToan>(sql).ToList();
        }

        public List<ThanhToan> ReadThanhToan(string column, string values)
        {
            string sql = "select * from ThanhToan where " + column + "=" + values;
            return db.Database.SqlQuery<ThanhToan>(sql).ToList();
        }

        // năm và tháng ngày tháng toán 
        public List<ThanhToan> ReadTongThanhToan(string nam, string thang)
        {
            string sql = "select * from ThanhToan where Year(NgayThanhToan) =" + nam + "and Month(NgayThanhToan) =" + thang;
            return db.Database.SqlQuery<ThanhToan>(sql).ToList();
        }

        //Chi Tiết Thanh Toán
        public List<ChiTietThanhToan> ReadListChiTietThanhToan()
        {
            string sql = "select * from ChiTietThanhToan";
            return db.Database.SqlQuery<ChiTietThanhToan>(sql).ToList();
        }

        public List<ChiTietThanhToan> ReadChiTietThanhToan(string column, string values)
        {
            string sql = "select * from ChiTietThanhToan where " + column + "=" + values;
            return db.Database.SqlQuery<ChiTietThanhToan>(sql).ToList();
        }

        //Báo Cáo
        public List<BaoCao> ReadListBaoCao()
        {
            string sql = "select * from BaoCao";
            return db.Database.SqlQuery<BaoCao>(sql).ToList();
        }

        public List<BaoCao> ReadBaoCao(string column, string values)
        {
            string sql = "select * from BaoCao where " + column + "=" + values;
            return db.Database.SqlQuery<BaoCao>(sql).ToList();
        }

        //Sự Kiện
        public List<SuKien> ReadListSuKien()
        {
            string sql = "select * from SuKien";
            return db.Database.SqlQuery<SuKien>(sql).ToList();
        }

        public List<SuKien> ReadSuKien(string column, string values)
        {
            string sql = "select * from SuKien where " + column + "=" + values;
            return db.Database.SqlQuery<SuKien>(sql).ToList();
        }

        //Chi Tiet Su Kiẹn
        public List<ChiTietSuKien> ReadListChiTietSuKien()
        {
            string sql = "select * from ChiTietSuKien";
            return db.Database.SqlQuery<ChiTietSuKien>(sql).ToList();
        }

        public List<ChiTietSuKien> ReadChiTietSuKien(string column, string values)
        {
            string sql = "select * from ChiTietSuKien where " + column + "=" + values;
            return db.Database.SqlQuery<ChiTietSuKien>(sql).ToList();
        }

        //Loại Sự Kiện
        public List<LoaiSuKien> ReadListLoaiSuKien()
        {
            string sql = "select * from LoaiSuKien";
            return db.Database.SqlQuery<LoaiSuKien>(sql).ToList();
        }

        public List<LoaiSuKien> ReadLoaiSuKien(string column, string values)
        {
            string sql = "select * from LoaiSuKien where " + column + "=" + values;
            return db.Database.SqlQuery<LoaiSuKien>(sql).ToList();
        }

        //Cụm máy
        public List<CumMay> ReadListCumMay()
        {
            string sql = "select * from CumMay";
            return db.Database.SqlQuery<CumMay>(sql).ToList();
        }

        public List<CumMay> ReadCumMay(string column, string values)
        {
            string sql = "select * from CumMay where " + column + "=" + values;
            return db.Database.SqlQuery<CumMay>(sql).ToList();
        }

        // Loại Cụm Máy
        public List<LoaiCumMay> ReadListLoaiCumMay()
        {
            string sql = "select * from LoaiCumMay";
            return db.Database.SqlQuery<LoaiCumMay>(sql).ToList();
        }

        public List<LoaiCumMay> ReadLoaiCumMay(string column, string values)
        {
            string sql = "select * from LoaiCumMay where " + column + "=" + values;
            return db.Database.SqlQuery<LoaiCumMay>(sql).ToList();
        }

        // Loai trang thai
        public List<LoaiTrangThai> ReadListLoaiTrangThai()
        {
            string sql = "select * from LoaiTrangThai";
            return db.Database.SqlQuery<LoaiTrangThai>(sql).ToList();
        }

        public List<LoaiTrangThai> ReadLoaiTrangThai(string column, string values)
        {
            string sql = "select * from LoaiTrangThai where " + column + "=" + values;
            return db.Database.SqlQuery<LoaiTrangThai>(sql).ToList();
        }

        //Chi Tiết Cụm Máy
        public List<ChiTietCumMay> ReadListChiTietCumMay()
        {
            string sql = "select * from ChiTietCumMay";
            return db.Database.SqlQuery<ChiTietCumMay>(sql).ToList();
        }

        public List<ChiTietCumMay> ReadChiTietCumMay(string column, string values)
        {
            string sql = "select * from ChiTietCumMay where " + column + "=" + values;
            return db.Database.SqlQuery<ChiTietCumMay> (sql).ToList();
        }

        //thiết Bị
        public List<ThietBi> ReadListThietBi()
        {
            string sql = "select * from ThietBi";
            return db.Database.SqlQuery<ThietBi>(sql).ToList();
        }

        public List<ThietBi> ReadThietBi(string column, string values)
        {
            string sql = "select * from ThietBi where " + column + "=" + values;
            return db.Database.SqlQuery<ThietBi>(sql).ToList();
        }

        //Thông số thiết Bị
        public List<ThongSoThietBi> ReadListThongSoThietBi()
        {
            string sql = "select * from ThongSoThietBi";
            return db.Database.SqlQuery<ThongSoThietBi>(sql).ToList();
        }

        public List<ThongSoThietBi> ReadThongSoThietBi(string column, string values)
        {
            string sql = "select * from ThongSoThietBi where " + column + "=" + values;
            return db.Database.SqlQuery<ThongSoThietBi>(sql).ToList();
        }

        // Dịch Vụ
        public List<DichVu> ReadListDichVu()
        {
            string sql = "select * from DichVu";
            return db.Database.SqlQuery<DichVu>(sql).ToList();
        }

        public List<DichVu> ReadDichVu(string column, string values)
        {
            string sql = "select * from DichVu where " + column + "=" + values;
            return db.Database.SqlQuery<DichVu>(sql).ToList();
        }

        //loại dịch vụ
        public List<LoaiDichVu> ReadListLoaiDichVu()
        {
            string sql = "select * from LoaiDichVu";
            return db.Database.SqlQuery<LoaiDichVu>(sql).ToList();
        }

        public List<LoaiDichVu> ReadLoaiDichVu(string column, string values)
        {
            string sql = "select * from LoaiDichVu where " + column + "=" + values;
            return db.Database.SqlQuery<LoaiDichVu>(sql).ToList();
        }

        //Nha Cung Cấp Dịch Vụ
        public List<NhaCungCapDichVu> ReadListNhaCungCapDichVu()
        {
            string sql = "select * from NhaCungCapDichVu";
            return db.Database.SqlQuery<NhaCungCapDichVu>(sql).ToList();
        }

        public List<NhaCungCapDichVu> ReadNhaCungCapDichVu(string column, string values)
        {
            string sql = "select * from NhaCungCapDichVu where " + column + "=" + values;
            return db.Database.SqlQuery<NhaCungCapDichVu>(sql).ToList();
        }

        //Nhập kho Dịch Vụ
        public List<NhapKhoDichVu> ReadListNhapKhoDichVu()
        {
            string sql = "select * from NhapKhoDichVu";
            return db.Database.SqlQuery<NhapKhoDichVu>(sql).ToList();
        }

        public List<NhapKhoDichVu> ReadNhapKhoDichVu(string column, string values)
        {
            string sql = "select * from NhapKhoDichVu where " + column + "=" + values;
            return db.Database.SqlQuery<NhapKhoDichVu>(sql).ToList();
        }

        // năm và tháng ngày tháng toán 
        public List<NhapKhoDichVu> ReadTongNhapKhoDichVu(string nam, string thang)
        {
            string sql = "select * from NhapKhoDichVu where Year(NgayNhapKho) =" + nam + "and Month(NgayNhapKho) =" + thang;
            return db.Database.SqlQuery<NhapKhoDichVu>(sql).ToList();
        }

        //Chi Tiết nhập kho
        public List<ChiTietNhapKho> ReadListChiTietNhapKho()
        {
            string sql = "select * from ChiTietNhapKho";
            return db.Database.SqlQuery<ChiTietNhapKho>(sql).ToList();
        }

        public List<ChiTietNhapKho> ReadChiTietNhapKho(string column, string values)
        {
            string sql = "select * from ChiTietNhapKho where " + column + "=" + values;
            return db.Database.SqlQuery<ChiTietNhapKho>(sql).ToList();
        }

        // Hu hai csvc 
        public List<HuHaiCSVC> ReadListHuHaiCSVC()
        {
            string sql = "select * from DichVu";
            return db.Database.SqlQuery<HuHaiCSVC>(sql).ToList();
        }

        public List<HuHaiCSVC> ReadHuHaiCSVC(string column, string values)
        {
            string sql = "select * from HuHaiCSVC where " + column + "=" + values;
            return db.Database.SqlQuery<HuHaiCSVC>(sql).ToList();
        }

    }
}
