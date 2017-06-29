using ServiceTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WarehouseManagementSystem.Helper;
//using System.Runtime.Caching;
using WMS.Model.Domain;
using WMS.Model.Resource;
using WMS.ServiceCommon.Contracts;
using WMS.ServicesCommon.Helpers;

namespace WarehouseManagementSystem.Controllers
{
		[Authorize]
		public class HomeController : BaseController
		{
				
				public IUserService UserService { get; set; }

				public IBasicService Service { get; set; }

				public IMaterialService MaterialService { get; set; }

				public ILocationService LocationService { get; set; }

				public ActionResult Index()
				{
						//Service.TestWritteReadEntitiesFromDB();
						//var list = LocationService.GetAllLocations();

						//ViewBag.Title = Service.GetMessage();

						//ViewBag.User = GetUserName();
						ViewBag.AvailableScreens = GetAvailableScreens(User.Identity.Name);
						
						return View();
				}

				/// <summary>
				/// Getr available screen based on user authorization
				/// </summary>
				/// <param name="user"></param>
				/// <returns></returns>
				public IList<MenuItem> GetAvailableScreens(string user)
				{
						var roles = UserService.GetRolesByUser(user);
						var tree = GetMenuTree();

						var result = FilterListByAuthRole(roles, tree.MenuItems.ToList());

						result = PruneTree(result);

						return result;
				}
				
				/// <summary>
				/// Remove child items without controller or action 
				/// </summary>
				/// <param name="result">Unpruned tree</param>
				private IList<MenuItem> PruneTree(IList<MenuItem> result)
				{
						result = result.Where(x => x.SubItems.Count > 0 || !string.IsNullOrEmpty(x.Controller)).ToList();

						foreach (var item in result)
						{
								item.SubItems = PruneTree(item.SubItems).ToList();
						}

						return result;
				}

				/// <summary>
				/// Create a list with the match between roles and the menu tree
				/// </summary>
				/// <param name="roles">the role list</param>
				/// <param name="items">the menu tree</param>
				/// <returns></returns>
				private IList<MenuItem> FilterListByAuthRole(IList<RoleAuthorization> roles, IList<MenuItem> items)
				{
						var result = items.Where(x => roles.Any(y => x.Authorization == y.Authorization && y.Access != WMS.Model.Enum.AccessType.None)).ToList();

						foreach (var item in result.Where(t => t.SubItems.Count > 0))
						{
								item.SubItems = FilterListByAuthRole(roles, item.SubItems).ToList();
						}

						return result;
				}

				/// <summary>
				/// Convert XML menu in a Menu object
				/// </summary>
				/// <returns>The custom object</returns>
				public Menu GetMenuTree()
				{
						//var cache = (Menu)MemoryCache.Default.Get("Menu_" + UserName());
						//if (cache == null || cache.Count == 0)
						//{
						//		cache = ReadMenuTreeFromFile();
						//}

						//return cache ?? new List<MenuItem>();

						var path = Path.GetFullPath(Path.Combine(GetPath(), @"..\Config\Menu.xml"));
						Menu result = (Menu) Deserialize.GetObjectFromXML(path, typeof(Menu));
						

						return result;
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