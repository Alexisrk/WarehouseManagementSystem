using System.Collections.Generic;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServiceCommon.Dao;

namespace WMS.Dao
{
		[Repository]
		public class UserMessageDao : BaseDao<UserMessage, System.Guid>, IUserMessageDao
		{
		}
}
