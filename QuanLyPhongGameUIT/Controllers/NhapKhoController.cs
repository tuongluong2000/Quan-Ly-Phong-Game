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
    public class NhapKhoController : Controller
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadNhapKhos());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NhapKhos model)
        {
            Create _create = new Create();

            var nhapkho = new NhapKhoDichVu
            {
                MaNhaCungCap = model.MaNhaCungCap,
                NgayNhapKho = model.NgayNhapKho,
                TongHoaDonNhap = model.TongHoaDonNhap,
                GhiChu = model.GhiChu,
                MaNhanVien = model.MaNhanVien,
            };
            _create.Add(nhapkho);
            _create.Save();

            var ctnk = new ChiTietNhapKho
            {
                MaNhapKho = nhapkho.MaHoaDonNhap,
                DichVuNhapKho = model.DichVuNhapKho,
                SoLuongNhap =model.SoLuongNhap,
                ChiPhiNhap = model.ChiPhiNhap,
            };
            _create.Add(ctnk);
            _create.Save();

            Update update = new Update();
            DichVu dichVu = update.UpdateDichVu(ctnk.DichVuNhapKho);
            dichVu.SoLuongConLai = dichVu.SoLuongConLai + ctnk.SoLuongNhap;
            update.Save();

            return RedirectToAction("Index");
        }

    }
}
