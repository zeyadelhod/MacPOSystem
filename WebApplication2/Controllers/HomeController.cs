using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAL;

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

        // GET api/values

        public List<POs> Get()
        {
            POs pos = new POs();

            //   List<Incident> SameUserIncidents = incidentsContext.Incidents.ToList().Where(x => incident.AndroidID == x.AndroidID).ToList();


            return pos.PurchaseOrders.ToList();
        }
    }
}