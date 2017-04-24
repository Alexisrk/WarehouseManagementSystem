using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using WMS.AuthorizationServer.Filters;
using System.Collections.Generic;
using WMS.Model.Model;
using WMS.ServiceCommon.Contracts;
using WMS.Model.Domain;

namespace WMS.AuthorizationServer.Controllers
{
    public class TokenController : Controller
				{
								private IClientService clientService;

								private ISecurityService securityService;

								//
								// POST: /Token/
								[HttpPost]
								public JsonResult Index(AuthorizationGrantModel model)
								{
												try
												{
																if (model.grant_type == "authorization_code")
																{
																				//Validate the code is used only once

																				var client = clientService.GetClient(model.client_id);

																				if (client == null)
																								return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);

																				if (!client.Secret.Equals(model.client_secret))
																								return Json(new { error = "invalid_client" }, JsonRequestBehavior.AllowGet);

																				var code = securityService.GetAuthorizationCode(model.code);

																				if (code == null)
																								return Json(new { error = "invalid_grant" }, JsonRequestBehavior.AllowGet);

																				if (!code.IdClient.Equals(client.Id))
																								return Json(new { error = "unauthorized_client" }, JsonRequestBehavior.AllowGet);

																				//Validate Uri match the client url registered

																				if (!string.IsNullOrEmpty(code.Redirect_Uri) && !code.Redirect_Uri.Equals(model.redirect_uri))
																								return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);

																				//Valid
																				var key = Convert.FromBase64String(client.Secret);
																				var provider = new System.Security.Cryptography.HMACSHA256(key);

																				var userID = code.IdUser;

																				var rawTokenInfo = string.Concat(code.Code, client.Secret, userID, DateTime.UtcNow.ToString("hhmmss"));
																				var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);
																				var token = provider.ComputeHash(rawTokenByte);

																				var rawRefreeshInfo = string.Concat(code.Code, client.Secret, DateTime.UtcNow.ToString("hhmmss"));
																				var rawRefreshByte = Encoding.UTF8.GetBytes(rawRefreeshInfo);
																				var refresh = provider.ComputeHash(rawRefreshByte);

																				var accessToken = new AccessToken()
																				{
																								IdClient = model.client_id,
																								IdUser = userID,
																								Token = Convert.ToBase64String(token),
																								Type = "bearer",
																								Expiration = DateTime.Now.AddDays(1),
																								RefreshToken = Convert.ToBase64String(refresh),
																								Scope = string.Empty
																				};

																				securityService.SaveAccessToken(accessToken);
																				return Json(new AccessTokenModel(accessToken), JsonRequestBehavior.AllowGet);
																}

																if (model.grant_type == "refresh_token" && !string.IsNullOrEmpty(model.refresh_token))
																{
																				//Validate the code is used only once

																				var client = clientService.GetClient(model.client_id);

																				if (client == null)
																								return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);

																				if (!client.Secret.Equals(model.client_secret))
																								return Json(new { error = "invalid_client" }, JsonRequestBehavior.AllowGet);

																				var oldToken = securityService.GetRefreshToken(model.refresh_token);

																				if (oldToken == null)
																								return Json(new { error = "invalid_grant" }, JsonRequestBehavior.AllowGet);

																				if (!oldToken.IdClient.Equals(client.Id))
																								return Json(new { error = "unauthorized_client" }, JsonRequestBehavior.AllowGet);

																				//Valid
																				var key = Convert.FromBase64String(client.Secret);
																				var provider = new System.Security.Cryptography.HMACSHA256(key);

																				var UserID = oldToken.IdUser;

																				var rawTokenInfo = string.Concat(oldToken.Token, client.Secret, DateTime.UtcNow.ToString("hhmmss"));
																				var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);
																				var token = provider.ComputeHash(rawTokenByte);

																				var accessToken = new AccessToken()
																				{
																								IdClient = model.client_id,
																								IdUser = UserID,
																								Token = Convert.ToBase64String(token),
																								Type = "bearer",
																								Expiration = DateTime.Now.AddDays(1),
																								RefreshToken = string.Empty,
																								Scope = string.Empty
																				};

																				securityService.SaveAccessToken(accessToken);
																				return Json(new AccessTokenModel(accessToken), JsonRequestBehavior.AllowGet);
																}

												}
												catch
												{
																return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);
												}

												return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);
								}
				}
}
