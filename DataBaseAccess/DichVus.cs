using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class DichVus
    {
        public int MaDichVu { set; get; }
        public int MaLoaiDichVu { set; get; }
        public int GiaKinhDoanh { set; get; }
        public int SoLuongConLai { set; get; }
        public string TenDichVu { set; get; }
        public string MoTa { set; get; }
        public string DonViTinh { set; get; }
        public DateTime NgayCapNhat { set; get; }
        public int HinhAnh { set; get; }
        public string TenLoaiDichVu { set; get; }
    }
}
