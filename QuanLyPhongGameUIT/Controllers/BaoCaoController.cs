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
    public class BaoCaoController : Controller
    {
        // GET: BaoCao
        public ActionResult Index()
        {
            Read _read = new Read();
            return View(_read.ReadListBaoCao());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BaoCao model)
        {
            Create _create = new Create();
            Read read = new Read();

            int TongChi = 0;
            int TongThu = 0;

            var ThanhToan = read.ReadTongThanhToan(model.Nam.ToString(), model.Thang.ToString());
            var NhapKho = read.ReadTongNhapKhoDichVu(model.Nam.ToString(), model.Thang.ToString());

            foreach (var thanhtoan in ThanhToan)
            {
                TongThu = TongThu + thanhtoan.TongThanhToan;
            }
            foreach (var nhapkho in NhapKho)
            {
                TongChi = TongChi + nhapkho.TongHoaDonNhap;
            }

            var ThenMoi = new BaoCao
            {
                Thang = model.Thang,
                Nam = model.Nam,
                TongThu = TongThu,
                TongChi = TongChi,
                TongLoiNhuan = TongThu -TongChi,
            };
            _create.Add(ThenMoi);
            _create.Save();

            return RedirectToAction("Index");
        }

        
    }
}
