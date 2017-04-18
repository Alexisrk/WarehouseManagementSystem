using System.Collections.Generic;
using WMS.Model.Domain;

namespace WMS.ServicesContract.Contracts
{
    public interface IUserServices
		{
				User GetUser(int userId);
		}
}
