using System.Collections.Generic;
using WMS.Model.Domain;

namespace WMS.ServiceCommon.Contracts
{
		/// <summary>
		/// User interface to handle all related users sucha as logins, permissions and roles.
		/// </summary>
		public interface IUserService
		{
				/// <summary>
				/// Get user by id
				/// </summary>
				/// <param name="id">user id</param>
				/// <returns>return an user</returns>
				User GetUser(int id);

				/// <summary>
				/// Get all roles for a user.
				/// It method searches roles permissions based on parent/child property
				/// </summary>
				/// <param name="userName">the user name</param>
				/// <returns>return a role list</returns>
				IList<Role> GetRolesByUser(string userName);
		}
}
