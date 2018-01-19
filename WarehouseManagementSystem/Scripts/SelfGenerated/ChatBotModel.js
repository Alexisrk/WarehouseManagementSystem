/// <reference path="../Scripts/typings/jquery/jquery.d.ts"/>
/// <reference path="../Scripts/typings/jqgrid/jqgrid.d.ts"/>
/// <reference path="Common.ts"/>
var ChatBotModel = (function () {
    function ChatBotModel() {
        this.ENTER_KEY_CODE = 13;
    }
    ChatBotModel.prototype.Initialize = function () {
        var _this = this;
        this.apiClient = window.getApiAiClient(this.accessTokenInput);
        this.InitHubClient();
        this.SendButtom.click(function () { return _this.PrepareTextToSent; });
        this.InputText.keydown(function (event) { return _this.KeyDownInputText(event); });
    };
    ChatBotModel.prototype.InitHubClient = function () {
        var _this = this;
        //InitChat
        this.hubClient = $.connection.chatHub;
        // Create a function that the hub can call back to display messages.
        this.hubClient.client.sendChatMessageToClient = function (message) {
            _this.AddChatResponseMessage(message);
        };
        this.hubClient.client.sendChatMessageToClient = function (message) {
            _this.AddChatResponseMessage(message);
        };
        //this.hubClient.client.sendUnreadMessages = messages => {
        //    this.AddUnreadMessages(messages);
        //};
        $.connection.hub.start().done(function () {
            _this.hubClient.server.join();
            _this.hubClientIsConnected = true;
            _this.CheckUnreadMessage();
        });
    };
    ChatBotModel.prototype.CheckUnreadMessage = function () {
        //if (this.hubClientIsConnected) {
        //    this.hubClient.server.checkUnreadMessages();
        //}
        var _this = this;
        $.ajax({
            url: 'Home/GetUnreadMessages',
            type: 'get',
            dataType: 'json',
            traditional: true,
            contentType: 'application/json; charset=utf-8',
            success: function (messages) {
                if (messages.data.length > 0) {
                    _this.AddUnreadMessages(messages.data);
                }
            }
        });
    };
    ChatBotModel.prototype.AddUnreadMessages = function (messages) {
        for (var i = 0; i < messages.length; i++) {
            var obj = messages[i];
            this.AddChatResponseMessage(obj.From + ': ' + obj.Message);
        }
    };
    ChatBotModel.prototype.PrepareTextToSent = function () {
        var rawMessage = this.InputText.val();
        if (rawMessage == '') {
            return;
        }
        this.InputText.val('');
        if (rawMessage.indexOf("@") >= 0) {
            this.SendDataToHub(rawMessage);
        }
        else {
            this.SendDataToIA(rawMessage);
        }
    };
    ChatBotModel.prototype.AddChatRequestMessage = function (message) {
        var node = document.createElement('div');
        node.className = "chatUserMessage";
        node.innerHTML = message;
        this.ChatContainer.appendChild(node);
        this.MoveScrollBar();
    };
    ChatBotModel.prototype.AddChatResponseMessage = function (message) {
        //check if chat is enabled
        if (!this.MainContainer.hasClass('in')) {
            var notificationNumber = Number(this.Badge.text()) + 1;
            this.Badge.text(notificationNumber);
        }
        else {
            this.hubClient.server.checkAllMessage();
        }
        var node = document.createElement('div');
        node.className = "chatIAMessage";
        node.innerHTML = message;
        this.ChatContainer.appendChild(node);
        this.MoveScrollBar();
        return node;
    };
    ChatBotModel.prototype.MoveScrollBar = function () {
        var jqChatContainer = $("#" + this.ChatContainer.id);
        jqChatContainer.scrollTop(jqChatContainer[0].scrollHeight);
    };
    ChatBotModel.prototype.SendDataToIA = function (rawMessage) {
        var _this = this;
        this.AddChatRequestMessage(rawMessage);
        var responseNode = this.AddChatResponseMessage('...');
        this.apiClient.textRequest(rawMessage)
            .then(function (response) {
            var resultValue;
            try {
                resultValue = response.result.fulfillment.speech;
                if (response.result.parameters != undefined && !response.result.actionIncomplete && !_this.isEmpty(response.result.parameters)) {
                    _this.sendDataToServer(response.result);
                }
            }
            catch (error) {
                resultValue = "";
            }
            _this.SetResponseJSON(response);
            _this.setResponseOnNode(resultValue, responseNode);
        })
            .catch(function (err) {
            this.SetResponseJSON(err);
            this.setResponseOnNode("Something goes wrong", responseNode);
        });
    };
    ChatBotModel.prototype.setResponseOnNode = function (response, node) {
        node.innerHTML = response ? response : "[empty response]";
        node.setAttribute('data-actual-response', response);
    };
    ChatBotModel.prototype.sendDataToServer = function (result) {
        var _this = this;
        var parameters = result.parameters;
        var actionParameters = [];
        for (var parameter in parameters) {
            actionParameters.push({
                Key: parameter,
                Value: parameters[parameter]
            });
        }
        this.hubClient.server.processAssistantQuery(actionParameters, result.action)
            .fail(function (error) {
            _this.AddChatResponseMessage(error);
        });
    };
    ChatBotModel.prototype.SendDataToHub = function (rawMessage) {
        // Call the Send method on the hub.
        this.hubClient.server.sendChatMessage(rawMessage);
        //queryInput.value = "";
        this.AddChatRequestMessage(rawMessage);
    };
    ChatBotModel.prototype.SetResponseJSON = function (response) {
        //var node = document.getElementById("jsonResponse");
        //node.innerHTML = JSON.stringify(response, null, 2);
    };
    ChatBotModel.prototype.KeyDownInputText = function (event) {
        if (event.keyCode !== this.ENTER_KEY_CODE) {
            return;
        }
        this.PrepareTextToSent();
    };
    ChatBotModel.prototype.isEmpty = function (obj) {
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop))
                return false;
        }
        return JSON.stringify(obj) === JSON.stringify({});
    };
    ChatBotModel.prototype.ClearBadge = function () {
        this.Badge.text('');
        this.hubClient.server.checkAllMessage();
    };
    return ChatBotModel;
}());
//# sourceMappingURL=ChatBotModel.js.map