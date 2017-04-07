using ServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using WMS.ServicesContract.Contracts;

namespace WarehouseManagementSystem.Controllers
{
  public class HomeController : Controller
  {
    public IBasicService Service { get; set; }

    public IMaterialService MaterialService { get; set; }

    public ILocationService LocationService { get; set; }
    
    public ActionResult Index()
    {
      var list = LocationService.GetAllLocations();

      ViewBag.Title = Service.GetMessage();

      return View();
    }
  }
}