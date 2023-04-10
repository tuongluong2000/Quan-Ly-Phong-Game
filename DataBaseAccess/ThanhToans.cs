using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class ThanhToans
    {
        //chi tiet thanh toan
        public int MaThanhToan { set; get; }
        public int MaKhachHang { set; get; }
        public int MaNhanVien { set; get; }
        public int TongThanhToan { set; get; }
        public string HinhThucThanhToan { set; get; }
        public int MaChiTietThanhToan { set; get; }
        public int MaDichVu { set; get; }
        public int SoLuongSuDung { set; get; }
        public string GhiChu { set; get; }
        public DateTime NgayThanhToan { set; get; }
        public string TenDichVu { set; get; }
        public int GiaKinhDoanh { set; get; }
        public int SoLuongConLai { set; get; }
        public string TenKhachHang { set; get; }
        public int LoaiKhachHang { set; get; }
        public string TenNhanVien { set; get; }
    }
}
