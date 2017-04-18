using System.Collections.Generic;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServicesContract.Dao;

namespace WMS.Dao
{
    [Repository]
    public class UserDao : BaseDao<User>, IUserDao
		{
    }
}
