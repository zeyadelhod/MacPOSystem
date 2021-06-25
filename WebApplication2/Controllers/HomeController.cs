using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public List<PurchaseOrderModel> Get()
        {
            POsDBContext pos = new POsDBContext();

          List<PurchaseOrderModel> SameUserIncidents = pos.PurchaseOrders.ToList().Where(x =>x.DealerName != "test").ToList();

         //   return Json(incidentsContext.Incidents.ToList(), JsonRequestBehavior.AllowGet);

            return SameUserIncidents;
        }

        [WebMethod]
        public JsonResult GetAllPOs()
        {
            POsDBContext pos = new POsDBContext();
           return Json(pos.PurchaseOrders.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}