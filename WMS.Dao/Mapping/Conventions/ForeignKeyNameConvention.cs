using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace WMS.Dao.Mapping.Conventions
{
		public class ForeignKeyNameConvention : ForeignKeyConvention
		{
				protected override string GetKeyName(Member property, Type type)
				{
						return "Id" + type.Name;
				}
		}
}
