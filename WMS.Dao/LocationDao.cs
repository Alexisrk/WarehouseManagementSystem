using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Transaction.Interceptor;
using WMS.Model.Domain;
using WMS.ServicesContract.Dao;

namespace WMS.Dao
{
    public class LocationDao : BaseDao, ILocationDao
    {
        [Transaction(ReadOnly = true)]
        public Location Get(string customerId)
        {
            return CurrentSession.Get<Location>(customerId);
        }

        [Transaction(ReadOnly = true)]
        public IList<Location> GetAll()
        {
            return GetAll<Location>();
        }
    }
}
