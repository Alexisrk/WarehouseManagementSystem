using ServiceTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using WarehouseManagementSystem.Helper;
//using System.Runtime.Caching;
using WMS.Model.Domain;
using WMS.Model.Resource;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Helpers;

namespace WarehouseManagementSystem.Controllers
{
		[Authorize]
		public class HomeController : BaseController
		{
				
				public IUserService UserService { get; set; }

				public IBasicService Service { get; set; }

				public IMaterialService MaterialService { get; set; }

				public ILocationService LocationService { get; set; }

				public IAssistantService AssistantService { get; set; }

				public ActionResult Index()
				{
						//Service.TestWritteReadEntitiesFromDB();
						//var list = LocationService.GetAllLocations();

						//ViewBag.Title = Service.GetMessage();

						//ViewBag.User = GetUserName();
						//ViewBag.AvailableScreens = GetAvailableScreens(User.Identity.Name);
						
						return View();
				}
				
				public JsonResult GetUnreadMessages()
				{
						var user = User.Identity.Name;

						var messages = AssistantService.GetAllUncheckMessages(user.Substring(user.IndexOf('\\') + 1));

						var jsonData = new
						{
								data = (
														from m in messages
														select new
														{
																m.Id,
																m.Message,
																m.Type,
																m.From,
																m.To,
																m.CreatedAt
														}).ToArray()
						};

						return Json(jsonData, JsonRequestBehavior.AllowGet);
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