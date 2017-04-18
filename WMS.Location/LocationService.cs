using System.Collections.Generic;
using log4net;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

namespace WMS.LocationManagement
{
    public class LocationService : ILocationService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ILocationDao LocalidadDao { get; set; }

        public IList<Location> GetAllLocations()
        {
            log.ErrorFormat("Test log");
            var list =  LocalidadDao.GetAll();
            return list;
        }
    }
}
