using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using MODEL;
using PagedList;
namespace WEBFORM.Controllers
{
    public class PhieuNhapController : Controller
    {
        // GET: PhieuNhap
        public ActionResult Index(phieunhapsearch s,int? page, int pagezise = 10)
        {
            loadnxb();
            int pageNumber = (page ?? 1);
            ViewBag.s = s;
            var model = PhieunhapServeic.GetAllBooks(s).ToPagedList(pageNumber, pagezise);
            if (Request.IsAjaxRequest())
            {
                return PartialView("list", model);
            }
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
        public ActionResult Create(phieunhap pn)
        {
            loadnxb();
            if (Request.IsAjaxRequest())
            {
                var res = PhieunhapServeic.Insert(pn);
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
            var nxbs = NxbServeic.GetAll();

            ViewBag.id_nxb = new SelectList(nxbs, "id", "name", selected);
        }
        [HttpPost]
        public ActionResult CreatePhieuthu(phieuchi pt)
        {
            if (Request.IsAjaxRequest())
            {
                var rq = PhieuChiService.insert(pt);
                return Json(rq, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public ActionResult listphieuthu(int id)
        {
            if (Request.IsAjaxRequest())
            {
                var model = PhieuChiService.GetAll(id);
                return PartialView(model);
            }
            return View();
        }
        public ActionResult Detail(int id)
        {
            var model = PhieunhapServeic.GetBookById(id);
            loadnxb(model.id_nxb);
            return View(model);
        }
    }
}