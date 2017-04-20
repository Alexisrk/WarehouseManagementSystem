using System;
using WMS.Model.Domain;
using WMS.ServiceCommon.Contracts;
using WMS.ServiceCommon.Dao;

namespace WMS.UserManagement
{
  public class AuthorizationCodeService : IAuthorizationCodeService
		{

				IAuthorizationCodeDao authorizationCodeDao;
				
			 public	bool Save(AuthorizationCode code)
				{
								authorizationCodeDao.Save(code);
								return true;								
				}
  }
}
