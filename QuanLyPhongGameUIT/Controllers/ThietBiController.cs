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
    public class ThietBiController : Controller
    {
        // GET: ThietBi
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadListThietBi());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ThietBi model)
        {
            Create _create = new Create();
            var loaitb = new LoaiThietBi
            {
                TenLoaiThietBi = "..."
            };
            _create.Add(loaitb);
            _create.Save();

            var tb = new ThietBi
            {
                TenThietBi = model.TenThietBi,
                TrangThai = model.TrangThai,
                HinhAnh = model.HinhAnh,
                LoaiThietBi = loaitb.MaLoaiThietBi,
                MoTa = model.MoTa,
                NgayCapNhat = DateTime.UtcNow,
                MaThongSo = model.MaThongSo,
            };
            _create.Add(tb);
            _create.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update _update = new Update();

            var thietBi = _update.UpdateThietBi((int)id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }
            //var loai = _update.UpdateLoaiThietBi(thietBi.LoaiThietBi);
            //var thongso = _update.UpdateThongSoThietBi(thietBi.MaThongSo);

            var model = new ThietBi
            {
                TenThietBi = thietBi.TenThietBi,
                HinhAnh = thietBi.HinhAnh,
                MoTa = thietBi.MoTa,
                MaThongSo = thietBi.MaThongSo,
                TrangThai = thietBi.TrangThai
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ThietBi model)
        {
            Update _update = new Update();
            try
            {
                var tb = _update.UpdateThietBi(model.MaThietBi);
                tb.TenThietBi = model.TenThietBi;
                tb.MoTa = model.MoTa;
                tb.HinhAnh = model.HinhAnh;
                tb.NgayCapNhat = DateTime.UtcNow;
                tb.MaThongSo = model.MaThongSo;
                tb.TrangThai = model.TrangThai;
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
            Update _update = new Update();

            var thietBi = _update.UpdateThietBi((int)id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }

            var model = new ThietBi
            {
                MaThietBi = thietBi.MaThietBi,
                TenThietBi = thietBi.TenThietBi,
                MoTa = thietBi.MoTa,
                HinhAnh = thietBi.HinhAnh,
                NgayCapNhat = thietBi.NgayCapNhat,
                MaThongSo = thietBi.MaThongSo,
                TrangThai = thietBi.TrangThai
                
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
            var thietBi = delete.DeleteThietBi((int)id);
            if (thietBi == null)
            {
                return HttpNotFound();
            }

            return View(thietBi);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Delete delete = new Delete();
            var thietBi = delete.DeleteThietBi(id);
            delete.DeleteObject(thietBi);
            delete.Save();
            return RedirectToAction("Index");
        }
    }
}