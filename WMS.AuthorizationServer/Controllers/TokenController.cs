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
using log4net;

namespace WMS.AuthorizationServer.Controllers
{
		public class TokenController : Controller
		{
				private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

				private IClientService clientService;

				private ISecurityService securityService;

				//
				// POST: /Token/
				/// <summary>
				/// Call Authorize to create or update Authorization token
				/// </summary>
				/// <param name="model">the current model</param>
				/// <returns>return the result in Json format</returns>
				[HttpPost]
				public JsonResult Index(AuthorizationGrantModel model)
				{
						try
						{
								log.Info("Create or update Token");

								if (model.grant_type == "authorization_code")
								{
										return CreateAccessToken(model);
								}

								if (model.grant_type == "refresh_token" && !string.IsNullOrEmpty(model.refresh_token))
								{
										return RefreshAccessToken(model);
								}

						}
						catch (Exception e)
						{
								log.Error("Error trying to get token.", e);
						}

						return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);
				}


				/// <summary>
				/// Refresh Authorization Code
				/// </summary>
				/// <param name="model">current model</param>
				/// <returns>return result on Json format</returns>
				private JsonResult RefreshAccessToken(AuthorizationGrantModel model)
				{
						log.Info("Refresh access token");

						var client = clientService.GetClient(model.client_id);

						if (client == null)
						{
								log.ErrorFormat("Client not found. Id [{0}]", model.client_id);
								return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);
						}

						if (!client.Secret.Equals(model.client_secret))
						{
								log.ErrorFormat("Client secret code doesn't match. model secret [{0}]", model.client_secret);
								return Json(new { error = "invalid_client" }, JsonRequestBehavior.AllowGet);
						}

						var oldToken = securityService.GetRefreshToken(model.refresh_token);

						if (oldToken == null)
						{
								log.ErrorFormat("Old access token not found", model.client_secret);
								return Json(new { error = "invalid_grant" }, JsonRequestBehavior.AllowGet);
						}

						if (!oldToken.Client.Id.Equals(client.Id))
						{
								log.ErrorFormat("Old access token client id mismatch. db Client [{0}] and model Client [{1}]", model.client_secret, client.Id);
								return Json(new { error = "unauthorized_client" }, JsonRequestBehavior.AllowGet);
						}

						//Valid
						AccessToken accessToken = securityService.CreateAccessToken(client, oldToken.User.Id, oldToken.Token, false);
						return Json(new AccessTokenModel(accessToken), JsonRequestBehavior.AllowGet);
				}

				/// <summary>
				/// Create Authorization Code
				/// </summary>
				/// <param name="model">current model</param>
				/// <returns>return result on Json format</returns>
				private JsonResult CreateAccessToken(AuthorizationGrantModel model)
				{
						var client = clientService.GetClient(model.client_id);

						if (client == null)
						{
								log.ErrorFormat("Client not found. Id [{0}]", model.client_id);
								return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);
						}

						if (!client.Secret.Equals(model.client_secret))
						{
								log.ErrorFormat("Client secret code doesn't match. model secret [{0}]", model.client_secret);
								return Json(new { error = "invalid_client" }, JsonRequestBehavior.AllowGet);
						}

						var code = securityService.GetAuthorizationCode(model.code);

						if (code == null)
						{
								log.ErrorFormat("Authorization code doens't exist");
								return Json(new { error = "invalid_grant" }, JsonRequestBehavior.AllowGet);
						}

						if (!code.IdClient.Equals(client.Id))
						{
								log.ErrorFormat("Old access token client id mismatch. db Client [{0}] and model Client [{1}]", code.IdClient, client.Id);
								return Json(new { error = "unauthorized_client" }, JsonRequestBehavior.AllowGet);
						}

						//Validate Uri match the client url registered
						if (!string.IsNullOrEmpty(code.Redirect_Uri) && !code.Redirect_Uri.Equals(model.redirect_uri))
						{
								log.ErrorFormat("Error uri mismatch between authorization code [{0}] and model code [{1}]", code.Redirect_Uri, model.redirect_uri);
								return Json(new { error = "invalid_request" }, JsonRequestBehavior.AllowGet);
						}

						AccessToken accessToken = securityService.CreateAccessToken(client, code.IdUser, code.Code, true);
						return Json(new AccessTokenModel(accessToken), JsonRequestBehavior.AllowGet);
				}

		}
}
