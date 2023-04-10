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
    public class NhanVienController : Controller
    {
        private Read _read = new Read();
        private Create _create = new Create();
        private Update _update = new Update();
        // GET: NhanVien
        public ActionResult Index()
        {
            return View(_read.ReadNhanViens());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NhanViens model)
        {
            
            var info = new Nguoi
            {
                HoTen = model.HoTen,
                DiaChi = model.DiaChi,
                SoDienThoai = model.SoDienThoai,
                CMND = model.Cmnd,
                Email = model.Email,
                Username = model.Username,
                Password = "123456",
                NgayTao = DateTime.UtcNow,
                Avartar = "123456",
                TrangThai = model.TrangThai
            };
            _create.Add(info);
            //_create.Save();

            var chucVu = new ChucVuNhanVien
            {
                TenChucVu = model.TenChucVu
            };
            _create.Add(chucVu);
            //_create.Save();

            var nhanVien = new NhanVien
            {
                MaNguoi = info.MaNguoi,
                MaChucVu = chucVu.MaChucVu
            };
            _create.Add(nhanVien);
            _create.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var nhanVien = _update.UpdateNhanVien((int)id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            var model = new NhanViens
            {
                MaNhanVien = nhanVien.MaNhanVien,
                MaNguoi = nhanVien.MaNguoi,
                MaChucVu = nhanVien.MaChucVu,
                HoTen = nhanVien.Nguoi.HoTen,
                DiaChi = nhanVien.Nguoi.DiaChi,
                SoDienThoai = nhanVien.Nguoi.SoDienThoai,
                Cmnd = nhanVien.Nguoi.CMND,
                Email = nhanVien.Nguoi.Email,
                TrangThai = nhanVien.Nguoi.TrangThai,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(NhanViens model)
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

            var nhanVien = _update.UpdateNhanVien((int)id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            var model = new NhanViens
            {
                MaNhanVien = nhanVien.MaNhanVien,
                MaNguoi = nhanVien.MaNguoi,
                MaChucVu = nhanVien.MaChucVu,
                HoTen = nhanVien.Nguoi.HoTen,
                DiaChi = nhanVien.Nguoi.DiaChi,
                SoDienThoai = nhanVien.Nguoi.SoDienThoai,
                Cmnd = nhanVien.Nguoi.CMND,
                Email = nhanVien.Nguoi.Email,
                TrangThai = nhanVien.Nguoi.TrangThai,
                Username = nhanVien.Nguoi.Username,
                NgayTao = nhanVien.Nguoi.NgayTao,
                TenChucVu = nhanVien.ChucVuNhanVien.TenChucVu
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
            var nhanVien = delete.DeleteNhanVien((int)id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }

            return View(nhanVien);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Delete delete = new Delete();
            var nhanVien = delete.DeleteNhanVien(id);
            delete.DeleteObject(nhanVien);
            delete.Save();
            return RedirectToAction("Index");
        }
    }
}