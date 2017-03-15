using System.Collections.Generic;
using WMS.Model.Domain;
using WMS.ServicesContract.Contracts;
using WMS.ServicesContract.Dao;

namespace WMS.MaterialManagement
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
