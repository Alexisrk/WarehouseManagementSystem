using System.Collections.Generic;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServicesContract.Dao;
using System;

namespace WMS.Dao
{
    [Repository]
    public class AccessTokenDao : BaseDao<AccessToken, Guid>, IAccessTokenDao
		{

		}
}
