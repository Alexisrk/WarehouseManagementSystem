using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.ServicesContract;
using WMS.ServicesContract.Contracts;
using WMS.ServicesContract.Dao;
using WMS.Model.Domain;

namespace WMS.MaterialService
{
    public class MaterialService : IMaterialService
    {
        public IMaterialDao MaterialDao { get; set; }

        public IList<Material> GetAllMaterials()
        {
            return MaterialDao.GetAll();
        }

    }
}
