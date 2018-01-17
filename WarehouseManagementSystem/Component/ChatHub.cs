using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WMS.ServicesCommon.Contracts;
using WMS.Model.Enum;

namespace Investigacion.Web.Components
{
		[HubName("chatHub")]
		public class ChatHub : Hub
		{
				private IAssistantService _assistantService;
				public IAssistantService AssistantService
				{
						get
						{
								if (_assistantService == null)
								{
										_assistantService = DependencyResolver.Current.GetService<IAssistantService>();
								}
								return _assistantService;
						}
				}

				public ChatHub()
				{

				}

				public void SendChatMessage(string message)
				{
						var targetName = message.Substring(1, message.IndexOf(' ') - 1);

						var innerMessage = message.Substring(message.IndexOf(' ') + 1);

						var sourceName = GetCurrentUserName();

						var newMessage = string.Format("{0}: {1}", sourceName, innerMessage);

						AssistantService.SaveMessage(sourceName, innerMessage, UserMessageType.Internal, targetName);
						Clients.Group(targetName).sendChatMessageToClient(newMessage);
				}

				public void CheckUnreadMessages()
				{
						var user = GetCurrentUserName();
						var messages = AssistantService.GetAllUncheckMessages(user);
						Clients.Group(user).sendUnreadMessages(messages);
				}

				public void CheckAllMessage()
				{
						AssistantService.CheckAllMessageForUser(GetCurrentUserName());
				}

				public void Join()
				{
						var sourceName = GetCurrentUserName();

						Groups.Add(Context.ConnectionId, sourceName);

						//Check permisos para escritura
						Clients.All.sendChatMessageToClient(sourceName + " joined.");
				}

				public void ProcessAssistantQuery(List<KeyValuePair<string, string>> actionParameters, AssistantAction action)
				{
						string user = Context.User.Identity.Name;
						string message = string.Empty;

						try
						{
								message = AssistantService.ProcessAction(user, actionParameters.ToDictionary(x => x.Key, x => x.Value), action);
						}
						//catch (GenericBaseException ex)
						//{
						//		message = ex.Message;
						//}
						catch (Exception e)
						{
								message = "Hubo un error al procesar la solicitud.";
						}

						Clients.Group(GetCurrentUserName()).sendChatMessageToClient(message);
				}

				private string GetCurrentUserName()
				{
						var userName = Context.User.Identity.Name;
						return userName.Substring(userName.IndexOf('\\') + 1);
				}

		}
}