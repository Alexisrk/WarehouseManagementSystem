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
    public class ClientMappingOverride : IAutoMappingOverride<Client>
    {

        public void Override(AutoMapping<Client> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
        }

    }
}
