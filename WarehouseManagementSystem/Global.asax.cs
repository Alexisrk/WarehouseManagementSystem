﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Spring.Web.Mvc;
using log4net;
using log4net.Config;
using Spring.Context;
using Spring.Context.Support;
using WarehouseManagementSystem;
using System.Web.Security;

namespace WarehouseManagementSystem
{
		public class WebApiApplication : SpringMvcApplication
		{
				private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

				protected void Application_Start()
				{
						log.Debug("Initializing program... ");

						XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Logging.config"));

						if (!LogManager.GetRepository().Configured)
								throw new Exception("log4net should has been configured.");
						
						AreaRegistration.RegisterAllAreas();
						GlobalConfiguration.Configure(WebApiConfig.Register);
						FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
						RouteConfig.RegisterRoutes(RouteTable.Routes);
						BundleConfig.RegisterBundles(BundleTable.Bundles);
						
						log.Debug("Calling start page");
				}

				//protected override System.Web.Http.Dependencies.IDependencyResolver BuildWebApiDependencyResolver()
				//{
				//  var resolver = base.BuildWebApiDependencyResolver();

				//  var springResolver = resolver as SpringWebApiDependencyResolver;

				//  //if it is, add additional config sources as needed
				//  if (springResolver != null)
				//  {
				//    springResolver.AddChildApplicationContextConfigurationLocation("file://~/Config/ChildControllers.xml");
				//  }

				//  return resolver;
				//}


				public static void RegisterGlobalFilters(GlobalFilterCollection filters)
				{
						filters.Add(new HandleErrorAttribute());
				}

				protected void Application_Error(object sender, EventArgs args)
				{
						Exception ex = Server.GetLastError();
						log.Error("webapp", ex);
						//  if (ex is HttpException)
						//  {
						//    Response.Redirect("~/Account/Error/" + ((HttpException)ex).GetHttpCode());
						//  }
						//  else
						//  {
						//    Response.Redirect("~/Account/Error");
						//  }
				}

				protected void Application_EndRequest(Object sender, EventArgs e)
				{
						if (HttpContext.Current.Response.Status.StartsWith("401"))
						{
								HttpContext.Current.Response.ClearContent();
								Response.Redirect("~/Account/Login");
						}
				}

				protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
				{
						var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
						if (authCookie != null)
						{
								FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
								if (authTicket != null && !authTicket.Expired)
								{
										var roles = authTicket.UserData.Split(',');
										HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
								}
						}
				}

		}
}
