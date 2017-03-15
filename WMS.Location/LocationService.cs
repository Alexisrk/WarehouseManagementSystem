using System.Collections.Generic;
using WMS.Model.Domain;
using WMS.ServicesContract.Contracts;
using WMS.ServicesContract.Dao;

namespace WMS.LocationManagement
{
    public class LocationService : ILocationService
    {
        public ILocationDao LocalidadDao { get; set; }

        public IList<Location> GetAllLocations()
        {
            return LocalidadDao.GetAll();
        }
    }
}
