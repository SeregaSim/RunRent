using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RunRent.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pricing()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Car()
        {
            return View();
        }
        public ActionResult CarSingle()
        {
            return View();
        }



    }
}