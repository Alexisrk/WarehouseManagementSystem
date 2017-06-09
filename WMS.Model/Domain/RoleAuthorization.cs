using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Enum;

namespace WMS.Model.Domain
{
		public class RoleAuthorization
		{
				//public virtual int IdRoleDefinition { get; set; }
				public virtual RoleDefinition RoleDefinition { get; set; }
				public virtual AuthorizationType Authorization { get; set; }
				public virtual AccessType Access { get; set; }


				public override bool Equals(object obj)
				{
						var other = obj as RoleAuthorization;

						if (ReferenceEquals(null, other)) return false;
						if (ReferenceEquals(this, other)) return true;

						return this.Authorization == other.Authorization &&
						//		this.IdRoleDefinition == other.IdRoleDefinition;
						this.RoleDefinition.Id == other.RoleDefinition.Id;
				}

				public override int GetHashCode()
				{
						unchecked
						{
								int hash = GetType().GetHashCode();
								hash = (hash * 31) ^ Authorization.GetHashCode();
								//hash = (hash * 31) ^ IdRoleDefinition.GetHashCode();
							 hash = (hash * 31) ^ RoleDefinition.Id.GetHashCode();

								return hash;
						}
				}
		}
}
