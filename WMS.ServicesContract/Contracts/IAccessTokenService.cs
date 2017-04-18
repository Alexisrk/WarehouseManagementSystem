using System.Collections.Generic;
using WMS.Model.Domain;

namespace WMS.ServicesContract.Contracts
{
    public interface IAccessTokenService
		{
				AuthorizationCode GetAuthToken(string token);
		}
}
