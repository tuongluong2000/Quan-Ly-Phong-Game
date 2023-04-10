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
    public class CumMayController : Controller
    {
        // GET: CumMay
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadCumMays());
        }

        public ActionResult Create()
        {
            return View();
        }
        // cum máy
        [HttpPost]
        public ActionResult Create(CumMays model)
        {
            Create _create = new Create();
            var loaicm = new LoaiCumMay
            {
                TenLoaiCumMay = model.TenLoaiCumMay,
            };
            _create.Add(loaicm);
            _create.Save();

            var loaitt = new LoaiTrangThai
            {
                TenLoaiTrangThai = model.TenLoaiTrangThai,
            };
            _create.Add(loaitt);
            _create.Save();

            var cumMay = new CumMay
            {
                SoThuTu = model.SoThuTu,
                LoaiCumMay = loaicm.MaLoaiCumMay,
                LoaiTrangThai = loaitt.MaLoaiTrangThai,
                ChiPhiThue = model.ChiPhiThue
            };
            _create.Add(cumMay);
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

            var cumMay = _update.UpdateCumMay((int)id);
            if (cumMay == null)
            {
                return HttpNotFound();
            }

            var model = new CumMay
            {
                SoThuTu = cumMay.SoThuTu,
                LoaiCumMay = cumMay.LoaiCumMay,
                LoaiTrangThai = cumMay.LoaiTrangThai,
                ChiPhiThue = cumMay.ChiPhiThue
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CumMays model)
        {
            Update _update = new Update();
            try
            {
                var cummay = _update.UpdateCumMay(model.MaCumMay);
                cummay.SoThuTu = model.SoThuTu;
                cummay.ChiPhiThue = model.ChiPhiThue;
                _update.Save();

                var loaicm = _update.UpdateLoaiCumMay(model.LoaiCumMay);
                loaicm.TenLoaiCumMay = model.TenLoaiCumMay;
                _update.Save();

                var loaitt = _update.UpdateLoaiTrangThai(model.LoaiTrangThai);
                loaitt.TenLoaiTrangThai = model.TenLoaiTrangThai;
                _update.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        

        // chi tiet cum may
        [HttpPost]
        public ActionResult CreateChiTietCumMay(CumMays model)
        {
            Create _create = new Create();
            var ctcm = new ChiTietCumMay
            {
                MaCumMay = model.MaCumMay,
                MaThietBi = model.MaThietBi,
            };
            _create.Add(ctcm);
            _create.Save();


            return RedirectToAction("Index");
        }

        public ActionResult UpdateChiTietThietBi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Update _update = new Update();

            var ctcummay = _update.UpdateChiTietCumMay((int)id);
            if (ctcummay == null)
            {
                return HttpNotFound();
            }

            var model = new ChiTietCumMay
            {
                MaChiTietCumMay = ctcummay.MaChiTietCumMay,
                MaCumMay = ctcummay.MaCumMay,
                MaThietBi = ctcummay.MaThietBi,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateChiTietCumMay(CumMays model)
        {
            Update _update = new Update();
            try
            {
                var ctcummay = _update.UpdateChiTietCumMay(model.MaChiTietCumMay);
                ctcummay.MaCumMay = model.MaCumMay;
                ctcummay.MaThietBi = model.MaThietBi;
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
