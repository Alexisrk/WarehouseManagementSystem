using System.Collections.Generic;
using WMS.Model.Domain;
using WMS.Model.Enum;

namespace WMS.ServiceCommon.Contracts
{
		public interface IAssistantService
		{
				string ProcessAction(string usuario, Dictionary<string, string> actionParameters, AssistantAction action);

				void SaveMessage(string fromUser, string message, UserMessageType type, string toUser);

				void CheckAllMessageForUser(string user);

				IList<UserMessage> GetAllUncheckMessages(string user);
		}
}
