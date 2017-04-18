﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTestServer.Filters
{
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Security.Principal;
		using System.Text;
		using System.Threading;
		using System.Web;
		using System.Web.Http.Filters;
		using WebMatrix.WebData;
		using System.Net.Http;
		using System.Net;
		using WMS.ServicesContract.Contracts;

		namespace TestBasic.Filters
		{
				public class ApiAuthorizeAttribute : AuthorizationFilterAttribute
				{
						private bool perUser;
						private IAccessTokenService tokenRepo;
						private IUserServices userRepo;

						public ApiAuthorizeAttribute(bool perUser = true)
						{
								this.perUser = perUser;
						}

						public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
						{
								const string TOKENNAME = "access_token";

								var query = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

								if (!string.IsNullOrWhiteSpace(query[TOKENNAME]))
								{
										var token = query[TOKENNAME];

										//this.tokenRepo = new AccessTokenRepository();
										var authToken = tokenRepo.GetAuthToken(token);

										if (authToken != null && authToken.Expiration > DateTime.Now)
										{
												if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
														return;

												//User repository
												var user = userRepo.GetUser(authToken.IdUser);

												if (user == null)
														return;

												var username = user.Name;
												var password = user.Password;

												if (!WebSecurity.Initialized)
														WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

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

						void HandleUnauthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
						{
								actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

								actionContext.Response.Headers.Add("WWW-Authenticate",
										"Basic Scheme='TestBasic' location='http://localhost/account/login'");
						}
				}
		}
}