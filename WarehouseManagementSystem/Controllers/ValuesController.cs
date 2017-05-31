using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehouseManagementSystem.Filters;

namespace WarehouseManagementSystem.Controllers
{
		[ApiAuthorize]
		public class ValuesController : ApiController
		{
				// GET api/values
				public List<string> Get()
				{
						return new List<string>()
												{ "Aplication", "access", "succesfully" };
				}

		}
}
