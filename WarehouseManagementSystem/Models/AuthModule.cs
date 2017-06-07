using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace WarehouseManagementSystem.Models
{
		public class AuthModule : IHttpModule
		{
				public void Init(HttpApplication context)
				{
						context.AuthenticateRequest += OnAuthenticateRequest;
				}

				private void OnAuthenticateRequest(object sender, EventArgs e)
				{
						var application = (HttpApplication)sender;
						var request = new HttpRequestWrapper(application.Request);

						var headers = request.Headers;
						var authData = headers["Authorization"];
						if (!string.IsNullOrEmpty(authData))
						{
								var scheme = authData.Substring(0, authData.IndexOf(' '));
								var parameter = authData.Substring(scheme.Length).Trim();
								var userPwd = Encoding.UTF8.GetString(Convert.FromBase64String(parameter));
								var user = userPwd.Substring(0, userPwd.IndexOf(':'));
								var password = userPwd.Substring(userPwd.IndexOf(':') +1);
								// Validamos user y password (aquí asumimos que siempre son ok)
								var principal = new GenericPrincipal(new GenericIdentity(user), null);
								PutPrincipal(principal);
						}
				}

				public void Dispose()
				{

				}

				private void PutPrincipal(IPrincipal principal)
				{
						Thread.CurrentPrincipal = principal;
						if (HttpContext.Current != null)
						{
								HttpContext.Current.User = principal;
						}
				}
		}
}