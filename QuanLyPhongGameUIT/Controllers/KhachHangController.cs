using DataBaseAccess;
using DBIO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyPhongGameUIT.Controllers
{
    public class KhachHangController : Controller
    {
        private Read _read = new Read();
        private Create _create = new Create();
        private Update _update = new Update();

        // GET: KhachHang
        public ActionResult Index()
        {
            return View(_read.ReadKhachHangs());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KhachHangs model)
        {
            var info = new Nguoi
            {
                HoTen = model.HoTen,
                DiaChi = model.DiaChi,
                SoDienThoai = model.SoDienThoai,
                CMND = model.Cmnd,
                Email = model.Email,
                Username = "client",
                Password = "123456",
                NgayTao = DateTime.UtcNow,
                Avartar = "123456",
                TrangThai = model.TrangThai
            };
            _create.Add(info);
            _create.Save();

            var loaikh = new LoaiKhachHang
            {
                TenLoaiKhachHang = model.TenLoaiKhachHang
            };
            _create.Add(loaikh);
            _create.Save();

            var kh = new KhachHang
            {
                MaLoaiKhachHang = loaikh.MaLoaiKhachHang,
                MaNguoi = info.MaNguoi,
            }
            ;
            _create.Add(kh);
            _create.Save();

            var loaithe = new LoaiTheThanhVien
            {
                TenLoaiTheThanhVien = model.TenLoaiTheThanhVien
            };
            _create.Add(loaithe);
            _create.Save();

            var the = new TheThanhVien
            {
                CapBacThe = model.CapBatThe,
                MaKhachHang = kh.MaKhachHang,
                MaLoaiTheThanhVien = loaithe.MaLoaiTheThanhVien,
                NgayKichHoat = DateTime.UtcNow,
                TinhTrangThe = model.TinhTrangThe
            };
            _create.Add(the);
            _create.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var khachHang = _update.UpdateKhachHang((int)id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }

            var model = new KhachHangs
            {
                MaKhachHang = khachHang.MaKhachHang,
                MaLoaiKhachHang = khachHang.MaLoaiKhachHang,
                MaNguoi = khachHang.MaNguoi,
                Cmnd = khachHang.Nguoi.CMND,
                HoTen = khachHang.Nguoi.HoTen,
                DiaChi = khachHang.Nguoi.DiaChi,
                Email = khachHang.Nguoi.Email,
                SoDienThoai = khachHang.Nguoi.SoDienThoai,
                TrangThai = khachHang.Nguoi.TrangThai,
                TenLoaiKhachHang = khachHang.LoaiKhachHang.TenLoaiKhachHang
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(KhachHangs model)
        {
            try
            {
                var info = _update.UpdateNguoi(model.MaNguoi);
                info.HoTen = model.HoTen;
                info.DiaChi = model.DiaChi;
                info.SoDienThoai = model.SoDienThoai;
                info.CMND = model.Cmnd;
                info.Email = model.Email;
                info.TrangThai = model.TrangThai;
                _update.Save();

                var loaikh = _update.UpdateLoaiKhachHang(model.MaLoaiKhachHang);
                loaikh.TenLoaiKhachHang = model.TenLoaiKhachHang;
                _update.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var khachHang = _update.UpdateKhachHang((int)id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }

            var model = new KhachHangs
            {
                MaKhachHang = khachHang.MaKhachHang,
                HoTen = khachHang.Nguoi.HoTen,
                DiaChi = khachHang.Nguoi.DiaChi,
                SoDienThoai = khachHang.Nguoi.SoDienThoai,
                Cmnd = khachHang.Nguoi.CMND,
                Email = khachHang.Nguoi.Email,
                TrangThai = khachHang.Nguoi.TrangThai,
                NgayTao = khachHang.Nguoi.NgayTao,
                TenLoaiKhachHang = khachHang.LoaiKhachHang.TenLoaiKhachHang,
            };
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delete delete = new Delete();
            var khacHang = delete.DeleteKhachHang((int)id);
            if (khacHang == null)
            {
                return HttpNotFound();
            }

            return View(khacHang);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Delete delete = new Delete();
            var khacHang = delete.DeleteKhachHang(id);
            delete.DeleteObject(khacHang);
            delete.Save();
            return RedirectToAction("Index");
        }
    }
}