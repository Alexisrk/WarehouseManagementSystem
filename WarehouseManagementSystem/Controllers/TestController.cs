using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WarehouseManagementSystem.Controllers
{

		[Authorize]
		[Route("api/test")]
		public class TestController : ApiController
  {
				// GET api/test
				public List<string> Get()
				{
						return new List<string>()
												{ "Test", "Authorization", "Succesfully" };
				}
		}
}
