using System;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

namespace WMS.UserManagement
{
    public class ClientService : IClientService
		{
				IClientDao clientDao;

				public Client GetClient(string id)
				{
						return clientDao.Get(id);
				}
		}
}
