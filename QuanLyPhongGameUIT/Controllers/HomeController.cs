using DataBaseAccess;
using DBIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyPhongGameUIT.Controllers
{
    public class HomeController : Controller
    {

        // đọc dữ liệu trong read
        // có 2 loại : đọc tất cả và đọc theo where cloumns = values

        public ActionResult Index()
        {
            return View(ReadThanhToans());
        }

        // Read Nhan vien
        List<NhanViens> ReadNhanViens ()
        {
            Read read = new Read();
            List<NhanViens> nhanvien = read.ReadNhanViens();
            return nhanvien;
        }

        // them nhân viên 
        [HttpPost]
        public JsonResult AddNhanVien(FormCollection data)
        {
            string HoTen = data["hoten"];
            string DiaChi = data["diachi"];
            string sdt = data["sdt"];
            string cmnd = data["cmnd"];
            string Email = data["email"];
            string UserName = data["username"];
            string pwd = data["pwd"];
            string pwd2 = data["pwd2"];
            string avt = data["avt"];
            string TrangThai = data["trangthai"];
            string ChucVu = data["chucvu"];
            DateTime NgayTao = DateTime.Now;
            int temp;

            JsonResult js = new JsonResult();
            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(HoTen) ||
                string.IsNullOrEmpty(DiaChi) ||
                string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(cmnd) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(pwd) ||
                string.IsNullOrEmpty(pwd2) ||
                string.IsNullOrEmpty(avt) ||
                string.IsNullOrEmpty(TrangThai)||
                string.IsNullOrEmpty(ChucVu))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };
                
            }
            else if (pwd !=pwd2)
            {
                js.Data = new
                {
                    status = "ER",
                    message = "mật khẩu không giống nhau"
                };
            }    
            else if(!(int.TryParse(sdt, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng số điện thoại"
                };
            }
            else if (!(int.TryParse(cmnd, out temp)))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng cmnd"
                };
            }
            else if (ChucVu != "1" && ChucVu != "2")
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập chức vụ 1 là quản lý , 2 là nhân viên "
                };
            }
            else
            {
                Create db = new Create();

                Nguoi nguoi = new Nguoi();
                nguoi.HoTen = HoTen;
                nguoi.DiaChi = DiaChi;
                nguoi.SoDienThoai = sdt;
                nguoi.CMND = cmnd;
                nguoi.Email = Email;
                nguoi.Username = UserName;
                nguoi.Password = pwd;
                nguoi.Avartar = avt;
                nguoi.TrangThai = TrangThai;
                nguoi.NgayTao = NgayTao;

                db.Add(nguoi);
                db.Save();

                NhanVien nhanvien = new NhanVien();
                nhanvien.MaNguoi = nguoi.MaNguoi;
                nhanvien.MaChucVu = int.Parse(ChucVu);

                db.Add(nhanvien);
                db.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // xoa nha vien
        [HttpPost]
        public JsonResult DeleteNhanVien(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id) )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();
                
               

                
                int values = int.Parse(id);
                NhanVien nhanvien  = delete.DeleteNhanVien(values);
                if (nhanvien == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(nhanvien);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua nhan vien
        [HttpPost]
        public JsonResult UpdateNhanVien(FormCollection data)
        {
            string HoTen = data["hoten"];
            string DiaChi = data["diachi"];
            string sdt = data["sdt"];
            string cmnd = data["cmnd"];
            string Email = data["email"];
            string TrangThai = data["trangthai"];
            string MaChuVu = data["chucvu"];
            string MaNguoi = data["manguoi"];
            string MaNhanVien = data["manhanvien"];

            int temp;

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(HoTen) ||
                string.IsNullOrEmpty(DiaChi) ||
                string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(cmnd) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(TrangThai))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if (!(int.TryParse(sdt, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng số điện thoại"
                };
            }
            else if (!(int.TryParse(cmnd, out temp)))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng cmnd"
                };
            }
            else
            {
                Update update = new Update();

                Nguoi nguoi = update.UpdateNguoi(int.Parse(MaNguoi));
                nguoi.HoTen = HoTen;
                nguoi.DiaChi = DiaChi;
                nguoi.SoDienThoai = sdt;
                nguoi.CMND = cmnd;
                nguoi.Email = Email;
                nguoi.TrangThai = TrangThai;

                update.Save();



                NhanVien nhanvien = update.UpdateNhanVien(int.Parse(MaNhanVien));
                nhanvien.MaChucVu = int.Parse(MaChuVu);

                update.Save();
               

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }


        // Read Khách hàng
        List<KhachHangs> ReadKhachHangs()
        {
            Read read = new Read();
            List<KhachHangs> KhachHang = read.ReadKhachHangs();
            return KhachHang;
        }

        // thêm khách hàng 
        [HttpPost]
        public JsonResult AddKhachHang(FormCollection data)
        {
            string HoTen = data["hoten"];
            string DiaChi = data["diachi"];
            string sdt = data["sdt"];
            string cmnd = data["cmnd"];
            string Email = data["email"];
            string UserName = "username";
            string pwd = "pwd";
            string pwd2 = "pwd";
            string avt = "không có";
            string TrangThai = data["trangthai"];
            string maloaikhachhang = data["maloaikhachhang"];
            DateTime NgayTao = DateTime.Now;
            DateTime NgayKichHoat = DateTime.Now;
            string MaLoaiTheThanhVien = data["maloaithethanhvien"];
            string TinhTrangThe = data["tinhtrangthe"];
            string CapBacThe = data["capbacthe"];

            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(HoTen) ||
                string.IsNullOrEmpty(DiaChi) ||
                string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(cmnd) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(pwd) ||
                string.IsNullOrEmpty(pwd2) ||
                string.IsNullOrEmpty(avt) ||
                string.IsNullOrEmpty(TrangThai) ||
                string.IsNullOrEmpty(maloaikhachhang)||
                string.IsNullOrEmpty(TinhTrangThe) ||
                string.IsNullOrEmpty(CapBacThe) ||
                string.IsNullOrEmpty(MaLoaiTheThanhVien))

            {
                
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không thể bỏ trống dữ liệu"
                    };
                }
            }
            else if (pwd != pwd2)
            {
                js.Data = new
                {
                    status = "ER",
                    message = "mật khẩu không giống nhau"
                };
            }
            else if (!(int.TryParse(sdt, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng số điện thoại"
                };
            }
            else if (!(int.TryParse(cmnd, out temp)))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng cmnd"
                };
            }
            else if (maloaikhachhang != "1" && maloaikhachhang != "2")
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập chức vụ 1 là quản lý , 2 là nhân viên "
                };
            }
            else
            {
                Create db = new Create();

                Nguoi nguoi = new Nguoi();
                nguoi.HoTen = HoTen;
                nguoi.DiaChi = DiaChi;
                nguoi.SoDienThoai = sdt;
                nguoi.CMND = cmnd;
                nguoi.Email = Email;
                nguoi.Username = UserName;
                nguoi.Password = pwd;
                nguoi.Avartar = avt;
                nguoi.TrangThai = TrangThai;
                nguoi.NgayTao = NgayTao;

                db.Add(nguoi);
                db.Save();

                KhachHang KhachHang = new KhachHang();
                KhachHang.MaNguoi = nguoi.MaNguoi;
                KhachHang.MaLoaiKhachHang = int.Parse(maloaikhachhang);

                db.Add(KhachHang);
                db.Save();

                // lấy thời gian hiện tại 
                double a = ((DateTime.Now.Year) - 2000)* 10000000000 + (DateTime.Now.Month) * 100000000 + (DateTime.Now.Day) * 1000000
                    + (DateTime.Now.Hour) * 10000 + (DateTime.Now.Minute) * 100 + (DateTime.Now.Second);

                String MaTheThanhVien = a.ToString();
                TheThanhVien thethanhvien = new TheThanhVien();
                //thethanhvien.MaTheThanhVien = MaTheThanhVien;
                thethanhvien.MaKhachHang = KhachHang.MaKhachHang;
                thethanhvien.NgayKichHoat = NgayKichHoat;
                thethanhvien.MaLoaiTheThanhVien = int.Parse(MaLoaiTheThanhVien);
                thethanhvien.TinhTrangThe = TinhTrangThe;
                thethanhvien.CapBacThe = int.Parse(CapBacThe);

                db.Add(thethanhvien);
                db.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // xoa khách hàng
        [HttpPost]
        public JsonResult DeleteKhachHang(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                KhachHang KhachHang = delete.DeleteKhachHang(values);
                if (KhachHang == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(KhachHang);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua khách hàng
        [HttpPost]
        public JsonResult UpdateKhachHang(FormCollection data)
        {
            string HoTen = data["hoten"];
            string DiaChi = data["diachi"];
            string sdt = data["sdt"];
            string cmnd = data["cmnd"];
            string Email = data["email"];
            string TrangThai = data["trangthai"];
            string MaLoaiKhachHang = data["maloaikhachhang"];
            string MaNguoi = data["manguoi"];
            string MaKhachHang = data["maKhachHang"];

            int temp;

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(HoTen) ||
                string.IsNullOrEmpty(DiaChi) ||
                string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(cmnd) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(TrangThai))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if (!(int.TryParse(sdt, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng số điện thoại"
                };
            }
            else if (!(int.TryParse(cmnd, out temp)))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng cmnd"
                };
            }
            else
            {
                Update update = new Update();

                Nguoi nguoi = update.UpdateNguoi(int.Parse(MaNguoi));
                nguoi.HoTen = HoTen;
                nguoi.DiaChi = DiaChi;
                nguoi.SoDienThoai = sdt;
                nguoi.CMND = cmnd;
                nguoi.Email = Email;
                nguoi.TrangThai = TrangThai;

                update.Save();



                KhachHang KhachHang = update.UpdateKhachHang(int.Parse(MaKhachHang));
                KhachHang.MaLoaiKhachHang = int.Parse(MaLoaiKhachHang);

                update.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }



        // Read Dich Vu
        List<DichVus> ReadDichVus()
        {
            Read read = new Read();
            List<DichVus> dichvu = read.ReadDichVus();
            return dichvu;
        }

        // them dịch vụ
        [HttpPost]
        public JsonResult AddDichVu(FormCollection data)
        {
            string TenDichVu = data["tendichvu"];
            string MaLoaiDichVu = data["maloaidichvu"];
            string GiaKinhDoanh = data["giakinhdoanh"];
            string DonViTinh = data["donvitinh"];
            string MoTa = data["mota"];
            string SoLuongConLai = "0";
            string HinhAnh = data["mahinhanh"];
            DateTime NgayCapNhat = DateTime.Now;
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(TenDichVu) ||
                string.IsNullOrEmpty(MaLoaiDichVu) ||
                string.IsNullOrEmpty(GiaKinhDoanh) ||
                string.IsNullOrEmpty(DonViTinh) ||
                string.IsNullOrEmpty(MoTa) 
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if (!(int.TryParse(HinhAnh, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng Hinh anh"
                };
            }
            else if (!(int.TryParse(MaLoaiDichVu, out temp)))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng ma loai dịch vụ"
                };
            }
            else
            {
                Create db = new Create();

                DichVu dichvu = new DichVu();
                dichvu.TenDichVu = TenDichVu;
                dichvu.LoaiDichVu = int.Parse(MaLoaiDichVu);
                dichvu.GiaKinhDoanh = int.Parse(GiaKinhDoanh);
                dichvu.DonViTinh = DonViTinh;
                dichvu.MoTa = MoTa;
                dichvu.SoLuongConLai = int.Parse(SoLuongConLai);
                dichvu.HinhAnh = int.Parse(HinhAnh);
                dichvu.NgayCapNhat = NgayCapNhat;

                db.Add(dichvu);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // xoa dịch vụ
        [HttpPost]
        public JsonResult DeleteDichVu(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                DichVu dichvu = delete.DeleteDichVu(values);
                if (dichvu == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(dichvu);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
 

        // sua dich vu
        [HttpPost]
        public JsonResult UpdateDichVu(FormCollection data)
        {
            string TenDichVu = data["tendichvu"];
            string MaLoaiDichVu = data["maloaidichvu"];
            string GiaKinhDoanh = data["giakinhdoanh"];
            string DonViTinh = data["donvitinh"];
            string MoTa = data["mota"];
            string HinhAnh = data["mahinhanh"];
            string MaDichVu = data["madichvu"];

            int temp;

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(TenDichVu) ||
                string.IsNullOrEmpty(MaLoaiDichVu) ||
                string.IsNullOrEmpty(GiaKinhDoanh) ||
                string.IsNullOrEmpty(DonViTinh) ||
                string.IsNullOrEmpty(MoTa)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if (!(int.TryParse(MaLoaiDichVu, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng ma loai dich vu"
                };
            }
            else if (!(int.TryParse(GiaKinhDoanh, out temp)))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng giá kinh doanh"
                };
            }
            else
            {
                Update update = new Update();

                DichVu dichvu = update.UpdateDichVu(int.Parse(MaDichVu));
                dichvu.TenDichVu = TenDichVu;
                dichvu.LoaiDichVu = int.Parse(MaLoaiDichVu);
                dichvu.GiaKinhDoanh = int.Parse(GiaKinhDoanh);
                dichvu.DonViTinh = DonViTinh;
                dichvu.MoTa = MoTa;
                dichvu.HinhAnh = int.Parse(HinhAnh);

                update.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }


        //read chi tiet thanh toan
        List<ThanhToans> ReadThanhToans()
        {
            Read read = new Read();
            List<ThanhToans> thanhtoan = read.ReadThanhToans();
            return thanhtoan;
        }



        // them thanh toan
        [HttpPost]
        public JsonResult AddThanhToan(FormCollection data)
        {
            string MaKhachHang = data["makhachhang"];
            string MaNhanVien = data["manhanvien"];
            string TongThanhToan = "0";
            string HinhThucThanhToan = "Tien mat";
            string GhiChu = data["ghichu"];
            DateTime NgayThanhToan = DateTime.Now;
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(MaKhachHang) ||
                string.IsNullOrEmpty(MaNhanVien) ||
                string.IsNullOrEmpty(TongThanhToan) 
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else
            {
                Create db = new Create();

                ThanhToan thanhtoan = new ThanhToan();
                thanhtoan.MaKhachHang = int.Parse(MaKhachHang);
                thanhtoan.MaNhanVien = int.Parse(MaNhanVien);
                thanhtoan.TongThanhToan = int.Parse(TongThanhToan);
                thanhtoan.NgayThanhToan = NgayThanhToan;
                thanhtoan.HinhThucThanhToan = HinhThucThanhToan;
                thanhtoan.GhiChu = GhiChu;

                db.Add(thanhtoan);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them chi tiet thanh toan
        [HttpPost]
        public JsonResult AddChiTietThanhToan(FormCollection data)
        {
            string MaThanhToan = data["mathanhtoan"];
            string MaDichVu = data["madichvu"];
            string SoLuongSuDung = data["soluongsudung"];
            int temp;

            JsonResult js = new JsonResult();

            Read read = new Read();

            // select * from Table where cloumn = values
            DichVu dichvu = read.ReadDichVu("MaDichVu", MaDichVu).FirstOrDefault();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(MaThanhToan) ||
                string.IsNullOrEmpty(MaDichVu) ||
                string.IsNullOrEmpty(SoLuongSuDung)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if (!(int.TryParse(SoLuongSuDung, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng so luong"
                };
            }
            else if(dichvu.SoLuongConLai < int.Parse(SoLuongSuDung))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "số lượng còn lại không đủ"
                };
            }    
            else
            {
                Create db = new Create();

                ChiTietThanhToan cttt = new ChiTietThanhToan();
                cttt.MaThanhToan = int.Parse(MaThanhToan);
                cttt.DichVuSuDung = int.Parse(MaDichVu);
                cttt.SoLuongSuDung = int.Parse(SoLuongSuDung);

                db.Add(cttt);
                db.Save();

                //update số lượng còn lại
                Update update = new Update();
                DichVu dv = update.UpdateDichVu(int.Parse(MaDichVu));
                dv.SoLuongConLai = dv.SoLuongConLai - int.Parse(SoLuongSuDung);
                update.Save();

                // upadate tổng thanh toán
                ThanhToan thanhtoan = update.UpdateThanhToan(int.Parse(MaThanhToan));
                thanhtoan.TongThanhToan = thanhtoan.TongThanhToan + dv.GiaKinhDoanh* int.Parse(SoLuongSuDung);
                update.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }


        // them cum máy 
        [HttpPost]
        public JsonResult AddCumMay(FormCollection data)
        {
            string SoThuTu = data["sothutu"];
            string LoaiCumMay = data["loaicummay"];
            string LoaiTrangThai = data["loaitrangthai"];
            string ChiPhiThue = data["chiphithue"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(SoThuTu) ||
                string.IsNullOrEmpty(LoaiCumMay) ||
                string.IsNullOrEmpty(LoaiTrangThai)||
                string.IsNullOrEmpty(ChiPhiThue)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(SoThuTu, out temp))) || (!(int.TryParse(LoaiTrangThai, out temp)))|| (!(int.TryParse(LoaiCumMay, out temp)))||(!(int.TryParse(ChiPhiThue, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Create db = new Create();

                CumMay cummay = new CumMay();
                cummay.SoThuTu = int.Parse(SoThuTu);
                cummay.LoaiCumMay = int.Parse(LoaiCumMay);
                cummay.LoaiTrangThai = int.Parse(LoaiTrangThai);
                cummay.ChiPhiThue = int.Parse(ChiPhiThue);

                db.Add(cummay);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCumMay(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                CumMay cm = delete.DeleteCumMay(values);
                if (cm == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(cm);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua cum may
        [HttpPost]
        public JsonResult UpdateCumMay(FormCollection data)
        {
            string MaCumMay = data["macummay"];
            string SoThuTu = data["sothutu"];
            string LoaiCumMay = data["loaicummay"];
            string LoaiTrangThai = data["loaitrangthai"];
            string ChiPhiThue = data["chiphithue"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(SoThuTu) ||
                string.IsNullOrEmpty(LoaiCumMay) ||
                string.IsNullOrEmpty(LoaiTrangThai) ||
                string.IsNullOrEmpty(ChiPhiThue)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(SoThuTu, out temp))) || (!(int.TryParse(LoaiTrangThai, out temp))) || (!(int.TryParse(LoaiCumMay, out temp))) || (!(int.TryParse(ChiPhiThue, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Update update = new Update();

                CumMay cummay = update.UpdateCumMay(int.Parse(MaCumMay));
                cummay.SoThuTu = int.Parse(SoThuTu);
                cummay.LoaiCumMay = int.Parse(LoaiCumMay);
                cummay.LoaiTrangThai = int.Parse(LoaiTrangThai);
                cummay.ChiPhiThue = int.Parse(ChiPhiThue);

                update.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }


        // Them Chi tiết cụm máy
        [HttpPost]
        public JsonResult AddChiTietCumMay(FormCollection data)
        {
            string MaCumMay = data["macummay"];
            string MaThietBi = data["mathietbi"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(MaCumMay) ||
                string.IsNullOrEmpty(MaThietBi) 
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(MaCumMay, out temp))) || (!(int.TryParse(MaThietBi, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Create db = new Create();

                ChiTietCumMay ctcm = new ChiTietCumMay();
                ctcm.MaCumMay = int.Parse(MaCumMay);
                ctcm.MaThietBi = int.Parse(MaThietBi);
                
                db.Add(ctcm);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        
        //xoa ctcm
        [HttpPost]
        public JsonResult DeleteChiTietCumMay(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                ChiTietCumMay ctcm = delete.DeleteChiTietCumMay(values);
                if (ctcm == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(ctcm);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua ct cum may
        [HttpPost]
        public JsonResult UpdateChiTietCumMay(FormCollection data)
        {
            string MaChiTietCumMay = data["machitietcummay"];
            string MaCumMay = data["macummay"];
            string MaThietBi = data["mathietbi"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(MaChiTietCumMay) ||
                string.IsNullOrEmpty(MaCumMay) ||
                string.IsNullOrEmpty(MaThietBi) 
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(MaThietBi, out temp))) || (!(int.TryParse(MaCumMay, out temp))) ) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Update update = new Update();

                ChiTietCumMay ctcm = update.UpdateChiTietCumMay(int.Parse(MaChiTietCumMay));
                ctcm.MaCumMay = int.Parse(MaCumMay);
                ctcm.MaThietBi = int.Parse(MaThietBi);

                update.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them thết bị
        [HttpPost]
        public JsonResult AddThietBi(FormCollection data)
        {
            string TenThietBi = data["tenthietbi"];
            string MoTa = data["mota"];
            string HinhAnh = data["hinhanh"];
            string LoaiThietBi = data["loaithietbi"];
            DateTime NgayCapNhat = DateTime.Now;
            string TrangThaiThietBi = data["trangthaithietbi"];
            string MaThongSo = data["mathongso"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(TenThietBi) ||
                string.IsNullOrEmpty(MoTa) ||
                string.IsNullOrEmpty(HinhAnh) ||
                string.IsNullOrEmpty(LoaiThietBi)||
                string.IsNullOrEmpty(TrangThaiThietBi)||
                string.IsNullOrEmpty(MaThongSo)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(LoaiThietBi, out temp))) || (!(int.TryParse(TrangThaiThietBi, out temp))) || (!(int.TryParse(MaThongSo, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Create db = new Create();

                ThietBi thietBi = new ThietBi();
                thietBi.TenThietBi = TenThietBi;
                thietBi.MoTa = MoTa;
                thietBi.HinhAnh = HinhAnh;
                thietBi.LoaiThietBi = int.Parse(LoaiThietBi);
                thietBi.NgayCapNhat = NgayCapNhat;
                thietBi.TrangThai = int.Parse(TrangThaiThietBi);
                thietBi.MaThongSo = int.Parse(MaThongSo);

                db.Add(thietBi);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        //xóa thiết bị
        [HttpPost]
        public JsonResult DeleteThietBi(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                ThietBi thietbi = delete.DeleteThietBi(values);
                if (thietbi == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(thietbi);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua thiết bị
        [HttpPost]
        public JsonResult UpdateThietBi(FormCollection data)
        {
            string TenThietBi = data["tenthietbi"];
            string MoTa = data["mota"];
            string HinhAnh = data["hinhanh"];
            string LoaiThietBi = data["loaithietbi"];
            DateTime NgayCapNhat = DateTime.Now;
            string TrangThaiThietBi = data["trangthaithietbi"];
            string MaThongSo = data["mathongso"];
            string MaThietBi = data["mathietbi"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(TenThietBi) ||
                string.IsNullOrEmpty(MoTa) ||
                string.IsNullOrEmpty(HinhAnh) ||
                string.IsNullOrEmpty(LoaiThietBi) ||
                string.IsNullOrEmpty(TrangThaiThietBi) ||
                string.IsNullOrEmpty(MaThongSo) ||
                string.IsNullOrEmpty(MaThietBi)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(LoaiThietBi, out temp))) || (!(int.TryParse(TrangThaiThietBi, out temp))) || (!(int.TryParse(MaThongSo, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Update update = new Update();

                ThietBi thietBi = update.UpdateThietBi(int.Parse(MaThietBi));
                thietBi.TenThietBi = TenThietBi;
                thietBi.MoTa = MoTa;
                thietBi.HinhAnh = HinhAnh;
                thietBi.LoaiThietBi = int.Parse(LoaiThietBi);
                thietBi.NgayCapNhat = NgayCapNhat;
                thietBi.TrangThai = int.Parse(TrangThaiThietBi);
                thietBi.MaThongSo = int.Parse(MaThongSo);

                update.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them thong số thết bị
        [HttpPost]
        public JsonResult AddThongSoThietBi(FormCollection data)
        {
            string NhaSanXuat = data["nhasanxuat"];
            string NamGioiThieu = data["namgioithieu"];
            string MoTa = data["mota"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(NhaSanXuat) ||
                string.IsNullOrEmpty(MoTa) ||
                string.IsNullOrEmpty(NamGioiThieu) 
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(NamGioiThieu, out temp))) ) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Create db = new Create();

                ThongSoThietBi thongSoThietBi = new ThongSoThietBi();
                thongSoThietBi.NhaSanXuat = NhaSanXuat;
                thongSoThietBi.NamGioiThieu = int.Parse(NamGioiThieu);
                thongSoThietBi.MoTa = MoTa;

                db.Add(thongSoThietBi);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        //xóa thông sô thiết bị
        [HttpPost]
        public JsonResult DeleteThongSoThietBi(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                ThongSoThietBi thongsothietbi = delete.DeleteThongSoThietBi(values);
                if (thongsothietbi == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(thongsothietbi);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua thông số thiết bị
        [HttpPost]
        public JsonResult UpdateThongSoThietBi(FormCollection data)
        {
            string NhaSanXuat = data["nhasanxuat"];
            string NamGioiThieu = data["namgioithieu"];
            string MoTa = data["mota"];
            string MaThongSo = data["mathongso"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(NhaSanXuat) ||
                string.IsNullOrEmpty(MoTa) ||
                string.IsNullOrEmpty(NamGioiThieu)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(NamGioiThieu, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Update update = new Update();

                ThongSoThietBi thongSoThietBi = update.UpdateThongSoThietBi(int.Parse(MaThongSo));
                thongSoThietBi.NhaSanXuat = NhaSanXuat;
                thongSoThietBi.NamGioiThieu = int.Parse(NamGioiThieu);
                thongSoThietBi.MoTa = MoTa;

                update.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }


        // them nhà cung cấp dịch vụ
        [HttpPost]
        public JsonResult AddNhaCungCapDichVu(FormCollection data)
        {
            string TenNhaCungCap = data["tennhacungcap"];
            string MSTNhaCungCap = data["mstnhacungcap"];
            string DiaChi = data["diachi"];
            string SoDienThoai = data["sodienthoai"];
            string GhiChu = data["ghichu"];
            string LoaiDichVuCungCap = data["loaidichvucungcap"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(TenNhaCungCap) ||
                string.IsNullOrEmpty(MSTNhaCungCap) ||
                string.IsNullOrEmpty(DiaChi) ||
                string.IsNullOrEmpty(SoDienThoai) ||
                string.IsNullOrEmpty(GhiChu) ||
                string.IsNullOrEmpty(LoaiDichVuCungCap)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(LoaiDichVuCungCap, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Create db = new Create();

                NhaCungCapDichVu nhaCungCapDichVu = new NhaCungCapDichVu();
                nhaCungCapDichVu.TenNhaCungCap = TenNhaCungCap;
                nhaCungCapDichVu.MSTNhaCungCap = MSTNhaCungCap;
                nhaCungCapDichVu.DiaChi = DiaChi;
                nhaCungCapDichVu.SoDienThoai = SoDienThoai;
                nhaCungCapDichVu.GhiChu = GhiChu;
                nhaCungCapDichVu.LoaiDichVuCungCap = int.Parse(LoaiDichVuCungCap);

                db.Add(nhaCungCapDichVu);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        //xóa nhà cung cấp dịch vụ
        [HttpPost]
        public JsonResult DeleteNhaCungCapDichVu(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                NhaCungCapDichVu nhaCungCapDichVu = delete.DeleteNhaCungCapDichVu(values);
                if (nhaCungCapDichVu == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(nhaCungCapDichVu);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua nhà cung cấp dịch vụ
        [HttpPost]
        public JsonResult UpdateNhaCungCapDichVu(FormCollection data)
        {
            string TenNhaCungCap = data["tennhacungcap"];
            string MSTNhaCungCap = data["mstnhacungcap"];
            string DiaChi = data["diachi"];
            string SoDienThoai = data["sodienthoai"];
            string GhiChu = data["ghichu"];
            string LoaiDichVuCungCap = data["loaidichvucungcap"];
            string MaNhaCungCap = data["manhacungcap"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(TenNhaCungCap) ||
                string.IsNullOrEmpty(MSTNhaCungCap) ||
                string.IsNullOrEmpty(DiaChi) ||
                string.IsNullOrEmpty(SoDienThoai) ||
                string.IsNullOrEmpty(GhiChu) ||
                string.IsNullOrEmpty(LoaiDichVuCungCap)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(LoaiDichVuCungCap, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Update update = new Update();

                NhaCungCapDichVu nhaCungCapDichVu = update.UpdateNhaCungCapDichVu(int.Parse(MaNhaCungCap));
                nhaCungCapDichVu.TenNhaCungCap = TenNhaCungCap;
                nhaCungCapDichVu.MSTNhaCungCap = MSTNhaCungCap;
                nhaCungCapDichVu.DiaChi = DiaChi;
                nhaCungCapDichVu.SoDienThoai = SoDienThoai;
                nhaCungCapDichVu.GhiChu = GhiChu;
                nhaCungCapDichVu.LoaiDichVuCungCap = int.Parse(LoaiDichVuCungCap);

                update.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them nhập kho
        [HttpPost]
        public JsonResult AddNhapKhoDichVu(FormCollection data)
        {
            string MaNhaCungCap = data["manhacungcap"];
            string TongHoaDonNhap = "0";
            string GhiChu = data["ghichu"];
            string MaNhanVien = data["manhanvien"];
            DateTime NgayNhapKho = DateTime.Now;
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(MaNhaCungCap) ||
                string.IsNullOrEmpty(GhiChu) ||
                string.IsNullOrEmpty(MaNhanVien) 
                
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(MaNhaCungCap, out temp)))|| (!(int.TryParse(MaNhanVien, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Create db = new Create();

                NhapKhoDichVu nhapKhoDichVu = new NhapKhoDichVu();
                nhapKhoDichVu.MaNhanVien = int.Parse(MaNhanVien);
                nhapKhoDichVu.MaNhaCungCap = int.Parse(MaNhaCungCap);
                nhapKhoDichVu.NgayNhapKho = NgayNhapKho;
                nhapKhoDichVu.TongHoaDonNhap = 0;
                nhapKhoDichVu.GhiChu = GhiChu;

                db.Add(nhapKhoDichVu);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        //xóa nhập kho
        [HttpPost]
        public JsonResult DeleteNhapKhoDichVu(FormCollection data)
        {
            string id = data["id"];

            JsonResult js = new JsonResult();

            if (string.IsNullOrEmpty(id))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không tồn tại dữ liệu"
                };

            }
            else
            {
                Delete delete = new Delete();




                int values = int.Parse(id);
                NhapKhoDichVu nhapKhoDichVu = delete.DeleteNhapKHoDichVu(values);
                if (nhapKhoDichVu == null)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "không tồn tại dữ liệu"
                    };
                }
                else
                {
                    delete.DeleteObject(nhapKhoDichVu);
                    delete.Save();

                    js.Data = new
                    {
                        status = "OK"
                    };
                }

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua nhập kho
        [HttpPost]
        public JsonResult UpdateNhapKhoDichVu(FormCollection data)
        {
            string MaNhaCungCap = data["manhacungcap"];
            string GhiChu = data["ghichu"];
            string MaNhanVien = data["manhanvien"];
            string MaHoaDonNhap = data["mahoadonnhap"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(MaNhaCungCap) ||
                string.IsNullOrEmpty(GhiChu) ||
                string.IsNullOrEmpty(MaNhanVien)

                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(MaNhaCungCap, out temp))) || (!(int.TryParse(MaNhanVien, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Update update = new Update();

                NhapKhoDichVu nhapKhoDichVu = update.UpdateNhapKhoDichVu(int.Parse(MaHoaDonNhap));
                nhapKhoDichVu.MaNhanVien = int.Parse(MaNhanVien);
                nhapKhoDichVu.MaNhaCungCap = int.Parse(MaNhaCungCap);
                nhapKhoDichVu.GhiChu = GhiChu;

                update.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them chi tiết nhập kho
        [HttpPost]
        public JsonResult AddChiTietNhapKho(FormCollection data)
        {
            string MaNhapKho = data["manhapkho"];
            string DichVuNhapKho = data["madichvu"];
            string SoLuongNhap = data["soluongnhap"];
            string ChiPhiNhap = data["chiphinhap"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(MaNhapKho) ||
                string.IsNullOrEmpty(DichVuNhapKho) ||
                string.IsNullOrEmpty(SoLuongNhap)  ||
                string.IsNullOrEmpty(ChiPhiNhap)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(MaNhapKho, out temp))) || (!(int.TryParse(DichVuNhapKho, out temp)))|| (!(int.TryParse(SoLuongNhap, out temp)))|| (!(int.TryParse(ChiPhiNhap, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập sai"
                };
            }
            else
            {
                Create db = new Create();

                ChiTietNhapKho chiTietNhapKho = new ChiTietNhapKho();
                chiTietNhapKho.MaNhapKho = int.Parse(MaNhapKho);
                chiTietNhapKho.DichVuNhapKho = int.Parse(DichVuNhapKho);
                chiTietNhapKho.SoLuongNhap = int.Parse(SoLuongNhap);
                chiTietNhapKho.ChiPhiNhap = int.Parse(ChiPhiNhap);

                db.Add(chiTietNhapKho);
                db.Save();

                Update update = new Update();

                DichVu dichVu = update.UpdateDichVu(chiTietNhapKho.DichVuNhapKho);
                dichVu.SoLuongConLai = dichVu.SoLuongConLai + chiTietNhapKho.SoLuongNhap;
                update.Save();

                NhapKhoDichVu nhapKhoDichVu = update.UpdateNhapKhoDichVu(chiTietNhapKho.MaNhapKho);
                nhapKhoDichVu.TongHoaDonNhap = nhapKhoDichVu.TongHoaDonNhap + chiTietNhapKho.ChiPhiNhap;
                update.Save();

                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }


        // them loại sự kiện
        [HttpPost]
        public JsonResult AddLoaiSuKien(FormCollection data)
        {
            string TenLoaiSuKien = data["tenloaisukien"]; 

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (
                string.IsNullOrEmpty(TenLoaiSuKien)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else
            {
                Create db = new Create();

                LoaiSuKien loaiSuKien = new LoaiSuKien();
                loaiSuKien.TenLoaiSuKien = TenLoaiSuKien;
                db.Add(loaiSuKien);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua loại sự kiên
        [HttpPost]
        public JsonResult UpdateLoaiSuKien(FormCollection data)
        {
            string TenSuKien = data["tensukien"];
            string MaLoaiSuKien = data["maloaisukien"];

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (
                string.IsNullOrEmpty(TenSuKien)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else
            {
                Update update = new Update();

                LoaiSuKien loaiSuKien = update.UpdateLoaiSuKien(int.Parse(MaLoaiSuKien));
                loaiSuKien.TenLoaiSuKien = TenSuKien;

                update.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them loại dich vu
        [HttpPost]
        public JsonResult AddLoaiDichVu(FormCollection data)
        {
            string Tenloaidichvu = data["tenloaidichvu"];

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (
                string.IsNullOrEmpty(Tenloaidichvu)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else
            {
                Create db = new Create();

                LoaiDichVu loaiDichVu = new LoaiDichVu();
                loaiDichVu.TenLoaiDichVu = Tenloaidichvu;
                db.Add(loaiDichVu);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // sua loại dich vu
        [HttpPost]
        public JsonResult UpdateLoaiDichVu(FormCollection data)
        {
            string TenLoaiDichVu = data["tenloaidichvu"];
            string MaLoaiDichVu = data["maloaidichvu"];

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (
                string.IsNullOrEmpty(TenLoaiDichVu)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else
            {
                Update update = new Update();

                LoaiDichVu loaiDichVu = update.UpdateLoaiDichVu(int.Parse(MaLoaiDichVu));
                loaiDichVu.TenLoaiDichVu = TenLoaiDichVu;

                update.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them sự kiện
        [HttpPost]
        public JsonResult AddSuKien(FormCollection data)
        {
            string TenSuKien = data["tensukien"];
            string MoTa = data["mota"];
            string MaLoaiSuKien = data["maloaisukien"];
            string NgayBatDau = data["ngaybatdau"];
            string NgayKetThuc = data["ngayketthuc"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(TenSuKien) ||
                string.IsNullOrEmpty(MoTa) ||
                string.IsNullOrEmpty(MaLoaiSuKien) ||
                string.IsNullOrEmpty(NgayBatDau) ||
                string.IsNullOrEmpty(NgayKetThuc)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if (!(int.TryParse(MaLoaiSuKien, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng "
                };
            }
            else
            {
                Create db = new Create();

                SuKien suKien = new SuKien();
                suKien.TenSuKien = TenSuKien;
                suKien.NgayBatDau = DateTime.Parse(NgayBatDau);
                suKien.NgayKetThuc = DateTime.Parse(NgayKetThuc);
                suKien.MoTa = MoTa;
                suKien.LoaiSuKien = int.Parse(MaLoaiSuKien);

                db.Add(suKien);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }


        // sua sụ kiện
        [HttpPost]
        public JsonResult UpdateSuKien(FormCollection data)
        {
            string TenSuKien = data["tensukien"];
            string MoTa = data["mota"];
            string MaLoaiSuKien = data["maloaisukien"];
            string NgayBatDau = data["ngaybatdau"];
            string NgayKetThuc = data["ngayketthuc"];
            string MaSuKien = data["masukien"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (string.IsNullOrEmpty(TenSuKien) ||
                string.IsNullOrEmpty(MoTa) ||
                string.IsNullOrEmpty(MaLoaiSuKien) ||
                string.IsNullOrEmpty(NgayBatDau) ||
                string.IsNullOrEmpty(NgayKetThuc)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if (!(int.TryParse(MaLoaiSuKien, out temp))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng "
                };
            }
            else
            {
                Update update = new Update();

                SuKien suKien = update.UpdateSuKien(int.Parse(MaSuKien));
                suKien.TenSuKien = TenSuKien;
                suKien.NgayBatDau = DateTime.Parse(NgayBatDau);
                suKien.NgayKetThuc = DateTime.Parse(NgayKetThuc);
                suKien.MoTa = MoTa;
                suKien.LoaiSuKien = int.Parse(MaLoaiSuKien);

                update.Save();

                js.Data = new
                {
                    status = "OK"
                };
            }
                return Json(js, JsonRequestBehavior.AllowGet);
        }

        // them báo cáo
        [HttpPost]
        public JsonResult AddBaoCao(FormCollection data)
        {
            string Nam = data["nam"];
            string Thang = data["thang"];
            int temp;

            JsonResult js = new JsonResult();

            // đầy đủ thông tin mới thêm được 
            if (
                string.IsNullOrEmpty(Nam) ||
                string.IsNullOrEmpty(Thang)
                )
            {
                js.Data = new
                {
                    status = "ER",
                    message = "không thể bỏ trống dữ liệu"
                };

            }
            else if ((!(int.TryParse(Nam, out temp)))|| (!(int.TryParse(Thang, out temp)))) // chỉ nhập số
            {
                js.Data = new
                {
                    status = "ER",
                    message = "nhập không đúng "
                };
            }
            else
            {
                Create db = new Create();
                Read read = new Read();
                int TongChi = 0;
                int TongThu = 0;

                var ThanhToan = read.ReadTongThanhToan(Nam,Thang);
                var NhapKho = read.ReadTongNhapKhoDichVu(Nam, Thang);

                foreach (var thanhtoan in ThanhToan)
                {
                    TongThu = TongThu + thanhtoan.TongThanhToan;
                }
                foreach (var nhapkho in NhapKho)
                {
                    TongChi = TongChi + nhapkho.TongHoaDonNhap;
                }

                BaoCao baoCao = new BaoCao();
                baoCao.Thang = int.Parse(Thang);
                baoCao.Nam = int.Parse(Nam);
                baoCao.TongChi = TongChi;
                baoCao.TongThu = TongThu;
                baoCao.TongLoiNhuan = TongThu - TongChi;

                db.Add(baoCao);
                db.Save();


                js.Data = new
                {
                    status = "OK"
                };

            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}