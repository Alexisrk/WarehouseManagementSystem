using System.Collections.Generic;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

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
