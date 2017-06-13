using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Enum;
using WMS.Model.Resource;

namespace WMS.Model.Domain
{
		public class RoleAuthorization
		{
				//public virtual int IdRoleDefinition { get; set; }
				public virtual RoleDefinition RoleDefinition { get; set; }

				[Display(ResourceType = typeof(LocalizedText), Name = "AuthorizationType")]
				public virtual AuthorizationType Authorization { get; set; }

				[Display(ResourceType = typeof(LocalizedText), Name = "AccessType")]
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
