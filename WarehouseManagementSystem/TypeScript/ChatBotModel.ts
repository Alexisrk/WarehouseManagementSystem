/// <reference path="../Scripts/typings/jquery/jquery.d.ts"/>
/// <reference path="../Scripts/typings/jqgrid/jqgrid.d.ts"/>
/// <reference path="Common.ts"/>

class ChatBotModel implements IChatBotModel {
    public ENTER_KEY_CODE = 13;

    public MainContainer: JQuery;
    public InputText: JQuery;
    public ChatContainer: HTMLElement;
    public SendButtom: JQuery;
    public Badge: JQuery;
    
    public accessTokenInput: string;
    public apiClient: any;
    public hubClient: any;

    public hubClientIsConnected: boolean;

    public Initialize() {
        this.apiClient = window.getApiAiClient(this.accessTokenInput);
        this.InitHubClient();
        this.SendButtom.click(() => this.PrepareTextToSent);
        this.InputText.keydown((event) => this.KeyDownInputText(event));
    }

    public InitHubClient() {
        //InitChat
        this.hubClient = $.connection.chatHub;
        // Create a function that the hub can call back to display messages.
								this.hubClient.client.sendChatMessageToClient = (message:any) => {
            this.AddChatResponseMessage(message);
        };

								this.hubClient.client.sendChatMessageToClient = (message:any) => {
            this.AddChatResponseMessage(message);
        };

        //this.hubClient.client.sendUnreadMessages = messages => {
        //    this.AddUnreadMessages(messages);
        //};

        $.connection.hub.start().done(() => {
            this.hubClient.server.join();
            this.hubClientIsConnected = true;
            this.CheckUnreadMessage();
        });
    }

    public CheckUnreadMessage() {
        //if (this.hubClientIsConnected) {
        //    this.hubClient.server.checkUnreadMessages();
        //}

        $.ajax({
            url: 'Home/GetUnreadMessages',
            type: 'get',
            dataType: 'json',
            traditional: true,
            contentType: 'application/json; charset=utf-8',
            success: (messages) => {
                if (messages.data.length > 0) {
                    this.AddUnreadMessages(messages.data);
                }
            }
        });
    }

    public AddUnreadMessages(messages: any) {
        for (var i = 0; i < messages.length; i++) {
            var obj = messages[i];
            this.AddChatResponseMessage(obj.From + ': ' + obj.Message);
        }
    }

    public PrepareTextToSent() {
        var rawMessage = this.InputText.val();

        if (rawMessage == '') {
            return;
        }

        this.InputText.val('');

        if (rawMessage.indexOf("@") >= 0) {
            this.SendDataToHub(rawMessage);
        } else {
            this.SendDataToIA(rawMessage);
        }
    }

    public AddChatRequestMessage(message: string) {
        var node = document.createElement('div');
        node.className = "chatUserMessage";
        node.innerHTML = message;
        this.ChatContainer.appendChild(node);
        this.MoveScrollBar();        
    }

    public AddChatResponseMessage(message: string) {
        //check if chat is enabled
        if (!this.MainContainer.hasClass('in')) {
            var notificationNumber = Number(this.Badge.text()) + 1;
            this.Badge.text(notificationNumber);
        } else {
            this.hubClient.server.checkAllMessage();
        }

        var node = document.createElement('div');
        node.className = "chatIAMessage";
        node.innerHTML = message;
        this.ChatContainer.appendChild(node);
        this.MoveScrollBar();        
        return node;
    }

    public MoveScrollBar() {
        var jqChatContainer = $("#" + this.ChatContainer.id);
        jqChatContainer.scrollTop(jqChatContainer[0].scrollHeight);
    }

    public SendDataToIA(rawMessage: string) {
        this.AddChatRequestMessage(rawMessage);

        var responseNode = this.AddChatResponseMessage('...');

        this.apiClient.textRequest(rawMessage)
										.then((response: any) => {
                var resultValue;
                try {
                    resultValue = response.result.fulfillment.speech;
                    if (response.result.parameters != undefined && !response.result.actionIncomplete && !this.isEmpty(response.result.parameters)) {
                        this.sendDataToServer(response.result);
                    }
                } catch (error) {
                    resultValue = "";
                }
                this.SetResponseJSON(response);
                this.setResponseOnNode(resultValue, responseNode);
            })
            .catch(function (err: any) {
                this.SetResponseJSON(err);
                this.setResponseOnNode("Something goes wrong", responseNode);
            });
    }

				public setResponseOnNode(response: any, node: any) {
        node.innerHTML = response ? response : "[empty response]";
        node.setAttribute('data-actual-response', response);
    }

				public sendDataToServer(result: any) {
        var parameters = result.parameters;
        var actionParameters = [];

        for (var parameter in parameters) {
            actionParameters.push({
                Key: parameter,
                Value: parameters[parameter]
            });
        }

        this.hubClient.server.processAssistantQuery(actionParameters, result.action)
										.fail((error: any) => {
                this.AddChatResponseMessage(error);
            });
    }

    public SendDataToHub(rawMessage: string) {
        // Call the Send method on the hub.
        this.hubClient.server.sendChatMessage(rawMessage);

        //queryInput.value = "";
        this.AddChatRequestMessage(rawMessage);
    }

				public SetResponseJSON(response: any) {
        //var node = document.getElementById("jsonResponse");
        //node.innerHTML = JSON.stringify(response, null, 2);
    }

				public KeyDownInputText(event: any) {
        if (event.keyCode !== this.ENTER_KEY_CODE) {
            return;
        }

        this.PrepareTextToSent();
    }

				public isEmpty(obj: any) {
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop))
                return false;
        }

        return JSON.stringify(obj) === JSON.stringify({});
    }

    public ClearBadge() {
        this.Badge.text('');
        this.hubClient.server.checkAllMessage();
    }
}
