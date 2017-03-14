using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using WMS.Model.Domain;

namespace WMS.Dao.Mapping
{
    class MaterialMappingOverride : IAutoMappingOverride<Material>
    {

        public void Override(AutoMapping<Material> mapping)
        {
            //mapping.HasMany(x => x.CaracteristicasVariables).Inverse().Cascade.AllDeleteOrphan();
            //mapping.HasMany(x => x.Aperturas).Inverse().Cascade.AllDeleteOrphan();
            //mapping.HasMany(x => x.FueraDeTipos).Inverse().Cascade.AllDeleteOrphan();
        }

    }
}
