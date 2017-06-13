using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using WMS.Model.Domain;
using WMS.Model.Enum;

namespace WMS.Dao.Mapping
{
		public class RoleAuthorizationMappingOverride : IAutoMappingOverride<RoleAuthorization>
		{

				public void Override(AutoMapping<RoleAuthorization> mapping)
				{
						mapping.CompositeId()
						.KeyReference(x => x.RoleDefinition, "IdRoleDefinition")
						.KeyProperty(x => x.Authorization, m => m.Type(typeof(AuthorizationType)));
						
						
						mapping.Map(x => x.Authorization).CustomType(typeof(AuthorizationType));
						mapping.Map(x => x.Access).CustomType(typeof(AccessType));
				}

		}
}
