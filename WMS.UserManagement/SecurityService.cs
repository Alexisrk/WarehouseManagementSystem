using System;
using System.Text;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

namespace WMS.UserManagement
{
		public class SecurityService : ISecurityService
		{

				IAuthorizationCodeDao authorizationCodeDao;

				IAccessTokenDao accessTokenDao;

				IUserDao userDao;

				public void SaveAuthorizationCode(AuthorizationCode code)
				{
						authorizationCodeDao.SaveOrUpdate(code);
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
						return accessTokenDao.Get(x => x.RefreshToken == refresh_token);
				}

				public void SaveAccessToken(AccessToken accessToken)
				{
						accessTokenDao.SaveOrUpdate(accessToken);
				}

				public AccessToken CreateAccessToken(Client client, int iduser, string code, bool refreshToken)
				{
						var user = userDao.Get(iduser);

						var key = Convert.FromBase64String(client.Secret);
						var provider = new System.Security.Cryptography.HMACSHA256(key);

						var rawTokenInfo = string.Concat(code, client.Secret, DateTime.UtcNow.ToString("hhmmss"));
						var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);
						var token = provider.ComputeHash(rawTokenByte);

						var refresh = string.Empty;
						if (refreshToken)
						{
								var rawRefreeshInfo = string.Concat(code, client.Secret, DateTime.UtcNow.ToString("hhmmss"));
								var rawRefreshByte = Encoding.UTF8.GetBytes(rawRefreeshInfo);
								refresh = Convert.ToBase64String(provider.ComputeHash(rawRefreshByte));
						}

						var accessToken = new AccessToken()
						{
								Client = client,
								User = user,
								Token = Convert.ToBase64String(token),
								Type = "bearer",
								Expiration = DateTime.Now.AddDays(1),
								RefreshToken = refresh,
								Scope = string.Empty
						};

						SaveAccessToken(accessToken);
						return accessToken;
				}

		}
}
