using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class NhapKhos
    {
        public int MaHoaDonNhapKho { set; get; }
        public int MaNhaCungCap { set; get; }
        public int TongHoaDonNhap { set; get; }
        public int MaNhanVien { set; get; }
        public int MaChiTietNhapKho { set; get; }
        public int DichVuNhapKho { set; get; }
        public int SoLuongNhap { set; get; }
        public string GhiChu { set; get; }
        public string TenDichVu { set; get; }
        public string TenNhanVien { set; get; }
        public string TenNhaCungCap { set; get; }
        public int ChiPhiNhap { set; get; }
        public DateTime NgayNhapKho { set; get; }
        
    }
}
