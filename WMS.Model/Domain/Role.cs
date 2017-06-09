using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Domain
{
		public class Role
		{
				public virtual int Id { get; set; }
				public virtual Role ParentRole { get; set; }
				public virtual RoleDefinition RoleDefinition { get; set; }
		}
}
