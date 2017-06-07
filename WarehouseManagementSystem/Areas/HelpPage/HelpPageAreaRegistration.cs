using System.Web.Http;
using System.Web.Mvc;

namespace WarehouseManagementSystem.Areas.HelpPage
{
		public class HelpPageAreaRegistration : AreaRegistration
		{
				public override string AreaName
				{
						get
						{
								return "HelpPage";
						}
				}

				public override void RegisterArea(AreaRegistrationContext context)
				{
						context.MapRoute(
										"WMS_HelpPage_Default",
										"Help/{action}/{apiId}",
										new { controller = "Help", action = "Index", apiId = UrlParameter.Optional },
										new[] { "WarehouseManagementSystem.Controllers" });

						HelpPageConfig.Register(GlobalConfiguration.Configuration);
				}
		}
}