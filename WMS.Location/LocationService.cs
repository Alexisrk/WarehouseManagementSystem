using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.ServicesContract;
using WMS.ServicesContract.Contracts;

namespace WMS.LocationService
{
    public class LocationService : ILocationService
    {
        public ILocationService LocalidadDao { get; set; }
    }
}
