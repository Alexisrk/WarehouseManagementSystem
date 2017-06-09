using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

namespace ServiceTest
{
		public class BasicService : IBasicService
		{
				private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



				public string GetMessage()
				{
						return "Test service message";
				}

				public void TestWritteReadEntitiesFromDB()
				{
					
				}
				
		}
}
