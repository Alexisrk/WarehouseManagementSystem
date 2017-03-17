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
    public class LocationMappingOverride : IAutoMappingOverride<Location>
    {

        public void Override(AutoMapping<Location> mapping)
        {
            mapping.Id(x => x.Name).GeneratedBy.Assigned();
        }

    }
}
