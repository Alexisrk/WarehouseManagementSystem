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

				public User GetUser(int id)
				{
						return userDao.Get(id);
				}

				public IList<Role> GetRolesByUser(string userName)
				{
						var user = userDao.Get(u => u.Name == userName);
						var roles = roleDao.GetAll();

						roles.FirstOrDefault(x => x.Id == user.Role.Id);

						var result = new List<Role>();
						GetRolesById(roles, user.Role.Id, result);

						return result;
				}

				public void GetRolesById(IList<Role> roles, int idRole, List<Role> result)
				{
						//Add current node
						var rolesFound = roles.Where(x => x.Id == idRole).ToList();
						result.AddRange(rolesFound);

						//Search child nodes by parent id
						foreach (var role in roles.Where(x => x.ParentRole.Id == idRole).ToList())
						{
								GetRolesById(roles, role.Id, result);
						}
				}
		}
}
