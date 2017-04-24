using System.Collections.Generic;
using WMS.Model.Domain;

namespace WMS.ServiceCommon.Contracts
{
  public interface ISecurityService
		{
				AuthorizationCode GetAuthorizationCode(string code);
				void SaveAuthorizationCode(AuthorizationCode code);
				AccessToken GetAccessToken(string token);
				AccessToken GetRefreshToken(string refresh_token);
				void SaveAccessToken(AccessToken accessToken);
		}
}
