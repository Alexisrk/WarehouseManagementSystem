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
    public class AccessTokenMappingOverride : IAutoMappingOverride<AccessToken>
    {

        public void Override(AutoMapping<AccessToken> mapping)
        {
            mapping.Id(x => x.Id).GeneratedBy.Assigned();
        }

    }
}
