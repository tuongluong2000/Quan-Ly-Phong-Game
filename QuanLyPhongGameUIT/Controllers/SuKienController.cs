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
    public class SuKienController : Controller
    {
        // GET: SuKien
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadListSuKien());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SuKien model)
        {
            Create _create = new Create();
   
           
            var sukien = new SuKien
            {
                TenSuKien = model.TenSuKien,
                NgayBatDau = model.NgayBatDau,
                NgayKetThuc = model.NgayKetThuc,
                MoTa = model.MoTa,
                LoaiSuKien = model.LoaiSuKien,
            };
            _create.Add(sukien);
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

            var sukien = _update.UpdateSuKien((int)id);
            if (sukien == null)
            {
                return HttpNotFound();
            }

            var model = new SuKien
            {
                MaSuKien = sukien.MaSuKien,
                TenSuKien = sukien.TenSuKien,
                NgayBatDau = sukien.NgayBatDau,
                NgayKetThuc = sukien.NgayKetThuc,
                MoTa = sukien.MoTa,
                LoaiSuKien = sukien.LoaiSuKien,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(SuKien model)
        {
            Update _update = new Update();
            try
            {
                var sukien = _update.UpdateSuKien(model.MaSuKien);
                sukien.TenSuKien = model.TenSuKien;
                sukien.NgayBatDau = model.NgayBatDau;
                sukien.NgayKetThuc = model.NgayKetThuc;
                sukien.MoTa = model.MoTa;
                sukien.LoaiSuKien = model.LoaiSuKien;
                _update.Save();

                
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

    }
}
