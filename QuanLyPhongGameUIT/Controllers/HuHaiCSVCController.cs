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
    public class HuHaiCSVCController : Controller
    {
        // GET: hu hai co so vat chat
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadListHuHaiCSVC());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HuHaiCSVC model)
        {
            Create _create = new Create();


            var huhai = new HuHaiCSVC
            {
                ThietBiHuHai = model.ThietBiHuHai,
                MoTa = model.MoTa,
                NgayHuHai = DateTime.Now,
                TinhTrang = model.TinhTrang,
                ChiPhiSuaChua = model.ChiPhiSuaChua
            };
            _create.Add(huhai);
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

            var huhai = _update.UpdateHuHaiCSVC((int)id);

            if (huhai == null)
            {
                return HttpNotFound();
            }

            var model = new HuHaiCSVC
            {
                MaHuHai = huhai.MaHuHai,
                ThietBiHuHai = huhai.ThietBiHuHai,
                MoTa = huhai.MoTa,
                NgayHuHai = huhai.NgayHuHai,
                TinhTrang = huhai.TinhTrang,
                ChiPhiSuaChua = huhai.ChiPhiSuaChua,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(HuHaiCSVC model)
        {
            Update _update = new Update();
            try
            {
                var huhai = _update.UpdateHuHaiCSVC(model.MaHuHai);
                huhai.ThietBiHuHai = model.ThietBiHuHai;
                huhai.MoTa = model.MoTa;
                huhai.TinhTrang = model.TinhTrang;
                huhai.ChiPhiSuaChua = model.ChiPhiSuaChua;
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
