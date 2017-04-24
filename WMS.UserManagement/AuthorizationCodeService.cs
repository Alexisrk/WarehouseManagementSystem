using System;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

namespace WMS.UserManagement
{
  public class SecurityService : ISecurityService
		{

				IAuthorizationCodeDao authorizationCodeDao;

				IAccessTokenDao accessTokenDao;
				
			 public	void SaveAuthorizationCode(AuthorizationCode code)
				{
								authorizationCodeDao.Save(code);				
				}

				public AuthorizationCode GetAuthorizationCode(string code)
				{
								return authorizationCodeDao.Get(x => x.Code == code);
				}

				public AccessToken GetAccessToken(string token)
				{
								return accessTokenDao.Get(x => x.Token == token);
				}

				public AccessToken GetRefreshToken(string refresh_token)
				{
								return accessTokenDao.Get(x => x.Token == refresh_token);
				}

				public void SaveAccessToken(AccessToken accessToken)
				{
								accessTokenDao.Save(accessToken);
				}
  }
}
