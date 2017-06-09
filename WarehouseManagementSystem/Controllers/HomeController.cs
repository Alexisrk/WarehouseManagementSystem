using log4net;
using ServiceTest;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WarehouseManagementSystem.Models;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;

namespace WarehouseManagementSystem.Controllers
{
		[Authorize]
		public class HomeController : Controller
		{
				private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

				public IUserService UserService { get; set; }

				public IBasicService Service { get; set; }

				public IMaterialService MaterialService { get; set; }

				public ILocationService LocationService { get; set; }

				public ActionResult Index()
				{
						//Service.TestWritteReadEntitiesFromDB();
						//var list = LocationService.GetAllLocations();

						//ViewBag.Title = Service.GetMessage();

						ViewBag.AvailableScreens = GetAvailableScreens(User.Identity.Name);

						return View();
				}

				public IList<string> GetAvailableScreens(string user)
				{
						var roles = UserService.GetRolesByUser(user);
						var tree = GetMenuGetMenuTree();

						return new List<string>();
				}

				public IList<string> GetMenuGetMenuTree()
				{
						return new List<string>();
				}

				//
				// Get: /Home/
				public ActionResult Connect(string code)
				{
						try
						{
								
								return Json("", JsonRequestBehavior.AllowGet);
						}
						catch (Exception e)
						{
								log.Error("Error trying to connect", e);
								return Json(e.Message, JsonRequestBehavior.AllowGet);
						}
				}

				//
				// POST: /Home/
				[HttpPost]
				public ActionResult Index(string something)
				{
						try
						{
								// TODO: Add insert logic here
								var urlHelper = new UrlHelper(Request.RequestContext);
								var server = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, urlHelper.Content("~"));
								var returnPath = string.Format("{0}{1}", server, "Home/Connect");
								var redirectUrl = string.Format("http://localhost:6699/oauth2/authorize?client_id={0}&redirect_uri={1}&state=optional-csrf-token&response_type=code"
												, urlHelper.Encode("bXljbGllbnRpZA==")
												, urlHelper.Encode(returnPath));

								return Redirect(redirectUrl);
						}
						catch (Exception e)
						{
								log.Error("Error calling the index", e);
								throw;
						}
				}
		}
}