using System.Collections.Generic;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServicesContract.Dao;

namespace WMS.Dao
{
    [Repository]
    public class MaterialDao : BaseDao, IMaterialDao
    {
        [Transaction(ReadOnly = true)]
        public Material Get(string customerId)
        {
            return CurrentSession.Get<Material>(customerId);
        }

        [Transaction(ReadOnly = true)]
        public IList<Material> GetAll()
        {
            return GetAll<Material>();
        }
    }
}
