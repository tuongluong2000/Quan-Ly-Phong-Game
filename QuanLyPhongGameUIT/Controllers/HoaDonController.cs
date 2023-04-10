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
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadThanhToans());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ThanhToans model)
        {
            Create _create = new Create();

            var thanhToan = new ThanhToan
            {
                MaKhachHang = model.MaKhachHang,
                MaNhanVien = model.MaNhanVien,
                TongThanhToan = model.TongThanhToan,
                NgayThanhToan = DateTime.Now,
                HinhThucThanhToan = model.HinhThucThanhToan,
                GhiChu = model.GhiChu,
            };
            _create.Add(thanhToan);
            _create.Save();

            var chiTietThanhToan = new ChiTietThanhToan
            {
                MaChiTietThanhToan = model.MaChiTietThanhToan,
                DichVuSuDung = model.MaDichVu,
                SoLuongSuDung = model.SoLuongSuDung,
            };
            _create.Add(chiTietThanhToan);
            _create.Save();

            Update update = new Update();
            DichVu dichVu = update.UpdateDichVu(chiTietThanhToan.DichVuSuDung);
            dichVu.SoLuongConLai = dichVu.SoLuongConLai - chiTietThanhToan.SoLuongSuDung;
            update.Save();

            return RedirectToAction("Index");
        }

    }
}
