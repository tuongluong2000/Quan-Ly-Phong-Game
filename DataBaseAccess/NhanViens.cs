using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class NhanViens
    {
        // tạo bảng mới đủ nội dung nhân viên 
        public int MaNguoi { set; get; }
        public int MaChucVu { set; get; }
        public int MaNhanVien { set; get; }
        public string HoTen { set; get; }
        public string DiaChi { set; get; }
        public string SoDienThoai { set; get; }
        public string Cmnd { set; get; }
        public string Email { set; get; }
        public string Username { set; get; }
        public DateTime NgayTao { set; get; }
        public string TrangThai { set; get; }
        public string TenChucVu { set; get; }
    }
}
