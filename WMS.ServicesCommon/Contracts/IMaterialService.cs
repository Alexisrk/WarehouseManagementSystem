using System.Collections.Generic;
using WMS.Model.Domain;

namespace WMS.ServiceCommon.Contracts
{
    public interface IMaterialService
    {
        IList<Material> GetAllMaterials();
    }
}
