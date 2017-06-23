using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WarehouseManagementSystem.Controllers
{
		public class BaseController : Controller
		{
				/// <summary>
				/// Static current logger
				/// </summary>
				protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

				/// <summary>
				/// Call the initialize before to each controller action
				/// </summary>
				/// <param name="requestContext">the context</param>
				protected override void Initialize(System.Web.Routing.RequestContext requestContext)
				{
						log.InfoFormat("execute controller {0}, action: {1}, user: {2}",
										requestContext.RouteData.GetRequiredString("controller"),
										requestContext.RouteData.GetRequiredString("action"),
										requestContext.HttpContext.User.Identity.Name);
						
						//Setting others properties such as the current culture, or redirect to show changes
						base.Initialize(requestContext);
				}

				/// <summary>
				/// Get current path
				/// </summary>
				/// <returns></returns>
				protected static string GetPath()
				{
						string codeBase = Assembly.GetExecutingAssembly().CodeBase;
						var uri = new UriBuilder(codeBase);
						string path = Uri.UnescapeDataString(uri.Path);
						return System.IO.Path.GetDirectoryName(path);
				}
		}
}