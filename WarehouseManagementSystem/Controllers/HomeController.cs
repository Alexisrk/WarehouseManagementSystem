using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceTest;
using WMS.ServicesContract.Contracts;

namespace WarehouseManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IBasicService Service { get; set; }

        public IMaterialService MaterialService { get; set; }


        public ActionResult Index()
        {

            ViewBag.Message = Service.GetMessage();

            var list = MaterialService.GetAllMaterials();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
