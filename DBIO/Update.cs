using DataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBIO
{
    public class Update
    {
        DB db = new DB();

        //lấy thông tin theo key

        public NhanVien UpdateNhanVien(int id)
        {
            return db.NhanViens.Where(c => c.MaNhanVien == id).FirstOrDefault();
        }

        public Nguoi UpdateNguoi(int id)
        {
            return db.Nguois.Where(c => c.MaNguoi == id).FirstOrDefault();
        }

        public ChucVuNhanVien UpdateChucVuNhanVien(int id)
        {
            return db.ChucVuNhanViens.Where(c => c.MaChucVu == id).FirstOrDefault();
        }

        public KhachHang UpdateKhachHang(int id)
        {
            return db.KhachHangs.Where(c => c.MaKhachHang == id).FirstOrDefault();
        }

        public LoaiKhachHang UpdateLoaiKhachHang(int id)
        {
            return db.LoaiKhachHangs.Where(c => c.MaLoaiKhachHang == id).FirstOrDefault();
        }

        public TheThanhVien UpdateTheThanhVien(int id)
        {
            return db.TheThanhViens.Where(c => c.MaTheThanhVien == id).FirstOrDefault();
        }

        public LoaiTheThanhVien UpdateLoaiTheThanhVien(int id)
        {
            return db.LoaiTheThanhViens.Where(c => c.MaLoaiTheThanhVien == id).FirstOrDefault();
        }

        public ThanhToan UpdateThanhToan(int id)
        {
            return db.ThanhToans.Where(c => c.MaThanhToan == id).FirstOrDefault();
        }

        public ChiTietThanhToan UpdateChiTietThanhToan(int id)
        {
            return db.ChiTietThanhToans.Where(c => c.MaChiTietThanhToan == id).FirstOrDefault();
        }

        public BaoCao UpdateBaoCao(int id)
        {
            return db.BaoCaos.Where(c => c.MaBaoCao  == id).FirstOrDefault();
        }

        public SuKien UpdateSuKien(int id)
        {
            return db.SuKiens.Where(c => c.MaSuKien == id).FirstOrDefault();
        }

        public ChiTietSuKien UpdateChiTietSuKien(int id)
        {
            return db.ChiTietSuKiens.Where(c => c.MaChiTietSuKien == id).FirstOrDefault();
        }

        public LoaiSuKien UpdateLoaiSuKien(int id)
        {
            return db.LoaiSuKiens.Where(c => c.MaLoaiSuKien == id).FirstOrDefault();
        }

        public CumMay UpdateCumMay(int id)
        {
            return db.CumMays.Where(c => c.MaCumMay == id).FirstOrDefault();
        }

        public LoaiCumMay UpdateLoaiCumMay(int id)
        {
            return db.LoaiCumMays.Where(c => c.MaLoaiCumMay == id).FirstOrDefault();
        }

        public LoaiTrangThai UpdateLoaiTrangThai(int id)
        {
            return db.LoaiTrangThais.Where(c => c.MaLoaiTrangThai == id).FirstOrDefault();
        }

        public ChiTietCumMay UpdateChiTietCumMay(int id)
        {
            return db.ChiTietCumMays.Where(c => c.MaChiTietCumMay == id).FirstOrDefault();
        }

        public ThietBi UpdateThietBi(int id)
        {
            return db.ThietBis.Where(c => c.MaThietBi == id).FirstOrDefault();
        }

        public LoaiThietBi UpdateLoaiThietBi(int id)
        {
            return db.LoaiThietBis.Where(c => c.MaLoaiThietBi == id).FirstOrDefault();
        }

        public ThongSoThietBi UpdateThongSoThietBi(int id)
        {
            return db.ThongSoThietBis.Where(c => c.MaThongSo == id).FirstOrDefault();
        }

        public HuHaiCSVC UpdateHuHaiCSVC(int id)
        {
            return db.HuHaiCSVCs.Where(c => c.MaHuHai == id).FirstOrDefault();
        }

        public DichVu UpdateDichVu(int id)
        {
            return db.DichVus.Where(c => c.MaDichVu == id).FirstOrDefault();
        }

        public LoaiDichVu UpdateLoaiDichVu(int id)
        {
            return db.LoaiDichVus.Where(c => c.MaLoaiDichVu == id).FirstOrDefault();
        }

        public NhaCungCapDichVu UpdateNhaCungCapDichVu(int id)
        {
            return db.NhaCungCapDichVus.Where(c => c.MaNhaCungCap == id).FirstOrDefault();
        }

        public NhapKhoDichVu UpdateNhapKhoDichVu(int id)
        {
            return db.NhapKhoDichVus.Where(c => c.MaHoaDonNhap == id).FirstOrDefault();
        }

        public ChiTietNhapKho UpdateChiTietNhapKho(int id)
        {
            return db.ChiTietNhapKhos.Where(c => c.MaChiTietNhapKho == id).FirstOrDefault();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
