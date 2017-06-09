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
		public class MaterialMappingOverride : IAutoMappingOverride<Material>
		{

				public void Override(AutoMapping<Material> mapping)
				{
						mapping.Id(x => x.Id).GeneratedBy.Assigned();
				}

		}
}
