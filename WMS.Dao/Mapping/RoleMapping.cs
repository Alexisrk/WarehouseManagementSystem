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
		public class RoleMappingOverride : IAutoMappingOverride<Role>
		{

				public void Override(AutoMapping<Role> mapping)
				{
						mapping.Id(x => x.Id).GeneratedBy.Increment();
						mapping.References(x => x.ParentRole); //.Column("IdParentRole");
						mapping.References(x => x.RoleDefinition);
				}

		}
}
