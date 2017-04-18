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

		//
		// Get: /Home/
		public ActionResult Connect(string code)
		{
				try
				{
						// TODO: Add insert logic here
						var urlHelper = new UrlHelper(Request.RequestContext);
						var server = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, urlHelper.Content("~"));
						var returnPath = string.Format("{0}{1}", server, "Home/Connect");
						var redirectUrl = string.Format("http://localhost:63226/oauth2/authorize?client_id={0}&redirect_uri={1}&state=optional-csrf-token&response_type=code"
								, urlHelper.Encode("bXljbGllbnRpZA==")
								, urlHelper.Encode(returnPath));

								//var result = RequestAccessToken(code, returnPath);

								//if (!string.IsNullOrEmpty(result.error))
								//{
								//		return Json(result, JsonRequestBehavior.AllowGet);
								//}

								//var resultRefresh = RequestAccessToken(result.refresh_token, returnPath, true);

								//if (!string.IsNullOrEmpty(resultRefresh.error))
								//{
								//		return Json(result, JsonRequestBehavior.AllowGet);
								//}

								//var data = CallApi(resultRefresh.access_token);

								//return Json(data, JsonRequestBehavior.AllowGet);
								return View();
						}
				catch
				{
						return View();
				}
		}
		}
}