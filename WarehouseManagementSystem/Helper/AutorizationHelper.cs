using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Helpers;
using Microsoft.AspNet.Identity;

namespace WarehouseManagementSystem.Helper
{
		public static class AutorizationHelper
		{
				private static IUserService _userService;
				public static IUserService UserService
				{
						get
						{
								if (_userService == null)
								{
										_userService = DependencyResolver.Current.GetService<IUserService>();
								}
								return _userService;
						}
				}
				
				/// <summary>
				/// Getr available screen based on user authorization
				/// </summary>
				/// <returns></returns>
				public static IList<MenuItem> GetAvailableScreens()
				{
						var user = HttpContext.Current.User.Identity.Name;

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
				private static IList<MenuItem> PruneTree(IList<MenuItem> result)
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
				private static IList<MenuItem> FilterListByAuthRole(IList<RoleAuthorization> roles, IList<MenuItem> items)
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
				public static Menu GetMenuTree()
				{
						//var cache = (Menu)MemoryCache.Default.Get("Menu_" + UserName());
						//if (cache == null || cache.Count == 0)
						//{
						//		cache = ReadMenuTreeFromFile();
						//}

						//return cache ?? new List<MenuItem>();

						var path = Path.GetFullPath(Path.Combine(GetPath(), @"..\Config\Menu.xml"));
						Menu result = (Menu)Deserialize.GetObjectFromXML(path, typeof(Menu));


						return result;
				}


				private static string GetPath()
				{
						string codeBase = Assembly.GetExecutingAssembly().CodeBase;
						var uri = new UriBuilder(codeBase);
						string path = Uri.UnescapeDataString(uri.Path);
						return Path.GetDirectoryName(path);
				}

		}
}