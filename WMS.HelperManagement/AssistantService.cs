using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Domain;
using WMS.Model.Enum;
using WMS.Model.Resource;
using WMS.ServiceCommon.Dao;
using WMS.ServiceCommon.Contracts;

namespace WMS.HelperManagement
{
		public class AssistantService : IAssistantService
		{
				private IUserMessageDao userMessageDao;
				
				public string ProcessAction(string usuario, Dictionary<string, string> actionParameters, AssistantAction action)
				{
						switch (action)
						{
								case AssistantAction.FindMaterial:
										var message = FindMaterialProperty(actionParameters);
										if (message == null)
										{
												message = LocalizedText.AssistantEmptyResult;
										}
										return message;
										break;
								case AssistantAction.ConectividadEstacion:
										//return CheckStationConectivity(actionParameters);
										break;
								case AssistantAction.FindLocation:
										//return FindLocalidadProperty(actionParameters);
										break;
								default:
										return string.Empty;
										break;
						}
						
						return string.Empty;
				}

				//[Transaction]
				public void SaveMessage(string fromUser, string message, UserMessageType type, string toUser)
				{
						var userMessage = new UserMessage
						{
								From = fromUser,
								To = toUser,
								Message = message,
								Type = type,
								CreatedAt = DateTime.Now,
								Checked = false,
						};

						//userMessageDao.Add(userMessage);
				}
				
				public void CheckAllMessageForUser(string user)
				{
						var messages = userMessageDao.GetAll(x => x.To == user && x.Checked == false);
						foreach (var message in messages)
						{
								message.Checked = true;
						}

						//userMessageDao.UpdateAll(messages);
				}

				public IList<UserMessage> GetAllUncheckMessages(string user)
				{
						return userMessageDao.GetAll(x => x.To == user && x.Checked == false);
				}

				#region Helpers
			
				private string FindMaterialProperty(Dictionary<string, string> actionParameters)
				{
						string message = String.Empty;

						var friendlyId = actionParameters[AssistantMaterialParameter.FriendlyId.ToString()];
						
						return friendlyId;

				}
				#endregion
		}
}
