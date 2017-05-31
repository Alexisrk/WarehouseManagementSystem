using System;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

namespace WMS.SecurityManagement
{
    public class UserService : IUserService
		{
				private IUserDao userDao;

				public User GetUser(int id)
				{
						return userDao.Get(id);
				}
		}
}
