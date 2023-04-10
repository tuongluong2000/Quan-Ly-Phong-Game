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
    public class NhaCungCapDichVuController : Controller
    {
        // GET: DichVu
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadListNhaCungCapDichVu());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NhaCungCapDichVu model)
        {
            Create _create = new Create();


            var ncc = new NhaCungCapDichVu
            {
                TenNhaCungCap = model.TenNhaCungCap,
                MSTNhaCungCap = model.MSTNhaCungCap,
                DiaChi = model.DiaChi,
                SoDienThoai = model.SoDienThoai,
                GhiChu = model.GhiChu,
                LoaiDichVuCungCap = model.LoaiDichVuCungCap,
            };
            _create.Add(ncc);
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

            var ncc = _update.UpdateNhaCungCapDichVu((int)id);
            if (ncc == null)
            {
                return HttpNotFound();
            }

            
            return View(ncc);
        }

        [HttpPost]
        public ActionResult Update(NhaCungCapDichVu model)
        {
            Update _update = new Update();
            try
            {
                var ncc = _update.UpdateNhaCungCapDichVu(model.MaNhaCungCap);
                ncc.TenNhaCungCap = model.TenNhaCungCap;
                ncc.MSTNhaCungCap = model.MSTNhaCungCap;
                ncc.DiaChi = model.DiaChi;
                ncc.SoDienThoai = model.SoDienThoai;
                ncc.GhiChu = model.GhiChu;
                ncc.LoaiDichVuCungCap = model.LoaiDichVuCungCap;
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
