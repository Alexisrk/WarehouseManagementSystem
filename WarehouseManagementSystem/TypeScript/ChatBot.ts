
var chatBotModel: ChatBotModel;

$(document).ready(() => {
    "use strict";

    chatBotModel = new ChatBotModel();

    chatBotModel.InputText = $("#chatMessageInput");
    chatBotModel.ChatContainer = document.getElementById("chatMessages");
    chatBotModel.MainContainer = $("#chatContainer");
    chatBotModel.SendButtom = $("#buttomChatMessage");
    chatBotModel.Badge = $(".badge");
    chatBotModel.accessTokenInput = '29b25250d2244ac8b34abc986d8d0526';

    chatBotModel.Initialize();

				$("#chatButtom").click(() => chatBotModel.ClearBadge());
});