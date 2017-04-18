using log4net;
using log4net.Config;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WMS.AuthorizationServer.App_Start;

namespace WMS.AuthorizationServer
{
	public class WebApiApplication : SpringMvcApplication
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected void Application_Start()
		{
				XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Logging.config"));

				if (!LogManager.GetRepository().Configured)
				throw new Exception("log4net should have been configured.");

				AreaRegistration.RegisterAllAreas();
				GlobalConfiguration.Configure(WebApiConfig.Register);
				FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
				RouteConfig.RegisterRoutes(RouteTable.Routes);
				BundleConfig.RegisterBundles(BundleTable.Bundles);
				AuthConfig.RegisterAuth();
		}
	}
}
