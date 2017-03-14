using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Domain;

namespace WMS.ServicesContract.Dao
{
    public interface IMaterialDao : IDao<Material, string> //, ISupportsDeleteDao<Customer>, ISupportsSave<Customer, string>
    {


    }
}
