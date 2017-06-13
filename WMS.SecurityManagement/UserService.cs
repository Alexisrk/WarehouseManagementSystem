using System;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;
using System.Collections.Generic;
using System.Linq;

namespace WMS.SecurityManagement
{
		public class UserService : IUserService
		{
				private IUserDao userDao;
				private IRoleDao roleDao;
				private IRoleAuthorizationDao roleAuthorizationDao;

				public User GetUser(int id)
				{
						return userDao.Get(id);
				}

				/// <summary>
				/// Get authorization roles by user
				/// </summary>
				/// <param name="userName">user name</param>
				/// <returns></returns>
				public IList<RoleAuthorization> GetRolesByUser(string userName)
				{
						var user = userDao.Get(u => u.Name == userName);
						var roles = roleDao.GetAll();
						
						var resultRoles = new List<Role>();
						GetRolesById(roles, user.Role.Id, resultRoles);

						var authList = GetAuthorizationByRoles(resultRoles);
						
						return authList;
				}

				private List<RoleAuthorization> GetAuthorizationByRoles(IList<Role> roles)
				{
						var result = new List<RoleAuthorization>();

						foreach (var role in roles)
						{
								var list = roleAuthorizationDao.GetAll(x => role.Id == x.RoleDefinition.Id).ToList();
								result.AddRange(list);
						}
						
						return result.Distinct().ToList();
				}

				/// <summary>
				/// Get all roles by user
				/// </summary>
				/// <param name="roles">all roles list</param>
				/// <param name="idRole">current id role</param>
				/// <param name="result">the result</param>
				public void GetRolesById(IList<Role> roles, int idRole, List<Role> result)
				{
						//Add current node
						var rolesFound = roles.Where(x => x.Id == idRole).ToList();
						result.AddRange(rolesFound);

						//Search child nodes by parent id
						foreach (var role in roles.Where(x => x.IdParentRole == idRole).ToList())
						{
								GetRolesById(roles, role.Id, result);
						}
				}
		}
}
