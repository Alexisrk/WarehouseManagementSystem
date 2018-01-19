using MvcJqGrid;
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
		public class LocationListController : BaseController
		{
				public ILocationService LocationService { get; set; }

				public ActionResult Index()
				{

						return View();
				}
				
				public ActionResult ListResultado(GridSettings grid)
				{
						var locations = LocationService.GetAllLocations();

						var jsonData = new
						{
								total = 1, // (int)Math.Ceiling((double)locations.TotalItems / locations.PageSize),
								page = 1, //locations.PageNumber,
								records = locations.Count, // locations.TotalItems,
								rows = (
																					from c in locations
																					select new
																					{
																							id = c.Name,
																							cell = new object[]
																																					{
																																																c.Name,
																																																c.Description,
																																																c.Type,
																																																c.W,
																																																c.B,
																																																c.A,
																																																c.X,
																																																c.Y,
																																																c.Z
																																					}
																					}).ToArray()
						};
						
						return Json(jsonData, JsonRequestBehavior.AllowGet);
				}
		}
}
