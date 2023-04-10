using DataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBIO
{
    public class Delete
    {
        DB db = new DB();

        public void DeleteObject<T>(T obj)
        {

            db.Set(obj.GetType()).Attach(obj);
            db.Set(obj.GetType()).Remove(obj);
            db.SaveChanges();
        }

        // lấy thông tin theo key
        public NhanVien DeleteNhanVien(int id)
        {
            return db.NhanViens.Where(c => c.MaNhanVien == id).FirstOrDefault();
        }

        public Nguoi DeleteNguoi(int id)
        {
            return db.Nguois.Where(c => c.MaNguoi == id).FirstOrDefault();
        }

        public ChucVuNhanVien DeleteChucVuNhanVien(int id)
        {
            return db.ChucVuNhanViens.Where(c => c.MaChucVu == id).FirstOrDefault();
        }

        public KhachHang DeleteKhachHang(int id)
        {
            return db.KhachHangs.Where(c => c.MaKhachHang == id).FirstOrDefault();
        }

        public LoaiKhachHang DeleteLoaiKhachHang(int id)
        {
            return db.LoaiKhachHangs.Where(c => c.MaLoaiKhachHang == id).FirstOrDefault();
        }

        public TheThanhVien DeleteTheThanhVien(int id)
        {
            return db.TheThanhViens.Where(c => c.MaTheThanhVien == id).FirstOrDefault();
        }

        public LoaiTheThanhVien DeleteLoaiTheThanhVien(int id)
        {
            return db.LoaiTheThanhViens.Where(c => c.MaLoaiTheThanhVien == id).FirstOrDefault();
        }

        public ThanhToan DeleteThanhToan(int id)
        {
            return db.ThanhToans.Where(c => c.MaThanhToan == id).FirstOrDefault();
        }

        public ChiTietThanhToan DeleteChiTietThanhToan(int id)
        {
            return db.ChiTietThanhToans.Where(c => c.MaChiTietThanhToan == id).FirstOrDefault();
        }

        public BaoCao DeleteBaoCao(int id)
        {
            return db.BaoCaos.Where(c => c.MaBaoCao == id).FirstOrDefault();
        }

        public SuKien DeleteSuKien(int id)
        {
            return db.SuKiens.Where(c => c.MaSuKien == id).FirstOrDefault();
        }

        public ChiTietSuKien DeleteChiTietSuKien(int id)
        {
            return db.ChiTietSuKiens.Where(c => c.MaChiTietSuKien == id).FirstOrDefault();
        }

        public LoaiSuKien DeleteLoaiSuKien(int id)
        {
            return db.LoaiSuKiens.Where(c => c.MaLoaiSuKien == id).FirstOrDefault();
        }

        public CumMay DeleteCumMay(int id)
        {
            return db.CumMays.Where(c => c.MaCumMay == id).FirstOrDefault();
        }

        public LoaiCumMay DeleteLoaiCumMay(int id)
        {
            return db.LoaiCumMays.Where(c => c.MaLoaiCumMay == id).FirstOrDefault();
        }

        public LoaiTrangThai DeleteLoaiTrangThai(int id)
        {
            return db.LoaiTrangThais.Where(c => c.MaLoaiTrangThai == id).FirstOrDefault();
        }

        public ChiTietCumMay DeleteChiTietCumMay(int id)
        {
            return db.ChiTietCumMays.Where(c => c.MaChiTietCumMay == id).FirstOrDefault();
        }

        public ThietBi DeleteThietBi(int id)
        {
            return db.ThietBis.Where(c => c.MaThietBi == id).FirstOrDefault();
        }

        public LoaiThietBi DeleteLoaiThietBi(int id)
        {
            return db.LoaiThietBis.Where(c => c.MaLoaiThietBi == id).FirstOrDefault();
        }

        public ThongSoThietBi DeleteThongSoThietBi(int id)
        {
            return db.ThongSoThietBis.Where(c => c.MaThongSo == id).FirstOrDefault();
        }

        public HuHaiCSVC DeleteHuHaiCSVC(int id)
        {
            return db.HuHaiCSVCs.Where(c => c.MaHuHai == id).FirstOrDefault();
        }

        public DichVu DeleteDichVu(int id)
        {
            return db.DichVus.Where(c => c.MaDichVu == id).FirstOrDefault();
        }

        public LoaiDichVu DeleteLoaiDichVu(int id)
        {
            return db.LoaiDichVus.Where(c => c.MaLoaiDichVu == id).FirstOrDefault();
        }

        public NhaCungCapDichVu DeleteNhaCungCapDichVu(int id)
        {
            return db.NhaCungCapDichVus.Where(c => c.MaNhaCungCap == id).FirstOrDefault();
        }

        public NhapKhoDichVu DeleteNhapKHoDichVu(int id)
        {
            return db.NhapKhoDichVus.Where(c => c.MaHoaDonNhap == id).FirstOrDefault();
        }

        public ChiTietNhapKho DeleteChiTietNhapKho(int id)
        {
            return db.ChiTietNhapKhos.Where(c => c.MaChiTietNhapKho == id).FirstOrDefault();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
