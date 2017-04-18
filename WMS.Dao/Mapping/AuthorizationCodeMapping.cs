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
    public class AuthorizationCodeMappingOverride : IAutoMappingOverride<AuthorizationCode>
    {

        public void Override(AutoMapping<AuthorizationCode> mapping)
        {
            mapping.Id(x => x.IdClient).GeneratedBy.Assigned();
        }

    }
}
