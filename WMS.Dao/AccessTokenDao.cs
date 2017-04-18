using System.Collections.Generic;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServiceCommon.Dao;
using System;
using WMS.ServiceCommon.Dao;

namespace WMS.Dao
{
    [Repository]
    public class AccessTokenDao : BaseDao<AccessToken, Guid>, IAccessTokenDao
		{

		}
}
