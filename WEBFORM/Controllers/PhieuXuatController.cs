using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MODEL;
using BUS;
using PagedList;
namespace WEBFORM.Controllers
{
    public class PhieuXuatController : Controller
    {
        // GET: PhieuXuat
        public ActionResult Index(phieuxuatSearch s,int? page,int pagezise=10)
        {
            loadnxb();
            int pageNumber = (page ?? 1);
            ViewBag.s = s;
            var model = PhieuxuatService.GetAllBooks(s).ToPagedList(pageNumber, pagezise);
            if (Request.IsAjaxRequest())
            {
                return PartialView("list", model);
            }
            return View(model);
        }
        public ActionResult Create(bookSearch bk)
        {
            loadnxb();
            return View();
        }
        [HttpPost]
        public ActionResult Create(phieuxuat pn)
        {
            loadnxb();
            if (Request.IsAjaxRequest())
            {
                var res = PhieuxuatService.Insert(pn);
                //kiem tra
                return Json(res, JsonRequestBehavior.AllowGet);
                
            }
            return View();
        }
        public ActionResult Sach(bookSearch bk)
        {
            var sach = SachService.GetBookByobj(bk);
            return PartialView(sach);
        }
        public void loadnxb(int? selected = null)
        {
            var nxbs = DailyService.GetAll();

            ViewBag.id_dl = new SelectList(nxbs, "id", "name", selected);
        }
        [HttpPost]
        public ActionResult CreatePhieuthu(phieuthu pt)
        {
            if (Request.IsAjaxRequest())
            {
                var rq = PhieuThuService.insert(pt);
                return Json(rq, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public ActionResult listphieuthu(int id)
        {
            if (Request.IsAjaxRequest())
            {
                var model = PhieuThuService.GetAll(id);
                return PartialView(model);
            }
            return View();
        }
        public ActionResult Detail(int id)
        {
            var model = PhieuxuatService.GetBookById(id);
            loadnxb(model.id_dl);
            return View(model);
        }
    }
}