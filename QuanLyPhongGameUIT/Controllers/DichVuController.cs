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
    public class DichVuController : Controller
    {
        // GET: DichVu
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadDichVus());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DichVus model)
        {
            Create _create = new Create();
            var loaidv = new LoaiDichVu
            {
                TenLoaiDichVu = model.TenLoaiDichVu
            };
            _create.Add(loaidv);
            _create.Save();

            var dv = new DichVu
            {
                DonViTinh = model.DonViTinh,
                GiaKinhDoanh = model.GiaKinhDoanh,
                HinhAnh = model.HinhAnh,
                LoaiDichVu = loaidv.MaLoaiDichVu,
                MoTa = model.MoTa,
                NgayCapNhat = DateTime.UtcNow,
                SoLuongConLai = model.SoLuongConLai,
                TenDichVu = model.TenDichVu
            };
            _create.Add(dv);
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

            var dichVu = _update.UpdateDichVu((int)id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }

            var model = new DichVus
            {
                DonViTinh = dichVu.DonViTinh,
                GiaKinhDoanh = dichVu.GiaKinhDoanh,
                HinhAnh = dichVu.HinhAnh,
                TenLoaiDichVu = dichVu.LoaiDichVu1.TenLoaiDichVu,
                MoTa = dichVu.MoTa,
                SoLuongConLai = dichVu.SoLuongConLai,
                TenDichVu = dichVu.TenDichVu
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(DichVus model)
        {
            Update _update = new Update();
            try
            {
                var dv = _update.UpdateDichVu(model.MaDichVu);
                dv.TenDichVu = model.TenDichVu;
                dv.MoTa = model.MoTa;
                dv.DonViTinh = model.DonViTinh;
                dv.GiaKinhDoanh = model.GiaKinhDoanh;
                dv.SoLuongConLai = model.SoLuongConLai;
                dv.HinhAnh = model.HinhAnh;
                dv.NgayCapNhat = DateTime.UtcNow;
                _update.Save();

                var loaidv = _update.UpdateLoaiDichVu(model.MaLoaiDichVu);
                loaidv.TenLoaiDichVu = model.TenLoaiDichVu;
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

            var dichVu = _update.UpdateDichVu((int)id);
            if (dichVu  == null)
            {
                return HttpNotFound();
            }

            var model = new DichVus
            {
                MaDichVu = dichVu.MaDichVu,
                MaLoaiDichVu = dichVu.LoaiDichVu,
                TenLoaiDichVu = dichVu.LoaiDichVu1.TenLoaiDichVu,
                DonViTinh = dichVu.DonViTinh,
                GiaKinhDoanh = dichVu.GiaKinhDoanh,
                MoTa = dichVu.MoTa,
                HinhAnh = dichVu.HinhAnh,
                NgayCapNhat = dichVu.NgayCapNhat,
                SoLuongConLai = dichVu.SoLuongConLai,
                TenDichVu = dichVu.TenDichVu
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
            var dichVu = delete.DeleteDichVu((int)id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }

            return View(dichVu);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Delete delete = new Delete();
            var dichVu = delete.DeleteDichVu(id);
            delete.DeleteObject(dichVu);
            delete.Save();
            return RedirectToAction("Index");
        }
    }
}
