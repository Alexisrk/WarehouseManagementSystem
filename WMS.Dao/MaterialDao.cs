using System.Collections.Generic;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServiceCommon.Dao;

namespace WMS.Dao
{
    [Repository]
    public class MaterialDao : BaseDao<Material>, IMaterialDao
    {
				[Transaction(ReadOnly = true)]
				public Material Get(string customerId)
				{
						return CurrentSession.Get<Material>(customerId);
				}
		}
}
