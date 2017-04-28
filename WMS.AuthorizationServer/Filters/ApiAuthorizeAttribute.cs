using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Filters;
using WebMatrix.WebData;
using System.Net.Http;
using System.Net;
using WMS.ServiceCommon.Contracts;
using log4net;
using Spring.Context.Support;

namespace WMS.AuthorizationServer.Filters
{
		public class ApiAuthorizeAttribute : AuthorizationFilterAttribute
		{
				private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

				private bool perUser;
				private ISecurityService securityService;
				private IUserService userService;

				public ApiAuthorizeAttribute(bool perUser = true)
				{
						this.perUser = perUser;

						if (ContextRegistry.IsContextRegistered("spring.root"))
						{
								this.securityService = (ISecurityService)ContextRegistry.GetContext().GetObject("securityService");
								this.userService = (IUserService)ContextRegistry.GetContext().GetObject("userService");
						}
				}

				public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
				{
						try
						{
								// Will return un-advised instance of proxy object
								//ISecurityService securityService = (ISecurityService)actionContext.ControllerContext.GetObject("securityService");

								const string TOKENNAME = "access_token";

								var query = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

								if (!string.IsNullOrWhiteSpace(query[TOKENNAME]))
								{
										var token = query[TOKENNAME];

										//this.tokenRepo = new AccessTokenRepository();
										var authToken = securityService.GetAccessToken(token);

										if (authToken != null && authToken.Expiration > DateTime.Now)
										{
												if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
														return;

												//User repository
												var user = userService.GetUser(authToken.User.Id);

												if (user == null)
														return;

												var username = user.Name;
												var password = user.Password;

												if (!WebSecurity.Initialized)
														WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "Id", "Name", autoCreateTables: true);

												if (WebSecurity.Login(username, password))
												{
														var principal = new GenericPrincipal(new GenericIdentity(username), null);
														Thread.CurrentPrincipal = principal;
														return;
												}
										}
								}
								HandleUnauthorized(actionContext);
						}
						catch (Exception e)
						{
								log.Error(e);
								throw;
						}
						
				}

				void HandleUnauthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
				{
						actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

						actionContext.Response.Headers.Add("WWW-Authenticate",
										"Basic Scheme='TestBasic' location='http://localhost/account/login'");
				}
		}

}