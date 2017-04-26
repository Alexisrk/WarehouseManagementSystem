using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Dao.Mapping.Conventions
{
		public class EnumConvention : IUserTypeConvention
		{
				public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
				{
						criteria.Expect(x => IsEnum(x) || IsNullableEnum(x));
				}

				private static bool IsEnum(IPropertyInspector pi)
				{
						return pi.Property.PropertyType.IsEnum;
				}

				private static bool IsNullableEnum(IPropertyInspector pi)
				{
						return pi.Property.PropertyType.IsGenericType &&
														pi.Property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
														pi.Property.PropertyType.GetGenericArguments().Single().IsEnum;
				}

				public void Apply(IPropertyInstance instance)
				{
						instance.CustomType(instance.Property.PropertyType);
				}
		}
}
