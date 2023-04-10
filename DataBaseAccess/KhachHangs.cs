using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class KhachHangs
    {
        public int MaNguoi { set; get; }
        public int MaLoaiKhachHang { set; get; }
        public int MaKhachHang { set; get; }
        public int MaLoaiTheThanhVien { set; get; }
        public string HoTen { set; get; }
        public string DiaChi { set; get; }
        public string SoDienThoai { set; get; }
        public string Cmnd { set; get; }
        public string Email { set; get; }
        public DateTime NgayTao { set; get; }
        public string TrangThai { set; get; }
        public string TenLoaiKhachHang { set; get; }
        public int MaTheThanhVien { set; get; }
        public DateTime NgayKichHoat { set; get; }
        public string TenLoaiTheThanhVien { set; get; }
        public string TinhTrangThe { set; get; }
        public int CapBatThe { set; get; }
    }
}
