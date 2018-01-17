
interface Window {

		getApiAiClient(accesstoken: string): any;

		sendTextToApiAi(text: string): any;

		showErrorAlert(message: string): any;
}

interface ApiAi {
		ApiAiClient(): any;
}

interface String {
		slice(separator: string): string;
}

interface JQuery {

		/* wrapped plugins */
		attr(input: string, value: boolean): any;

		dynatree(options: any): any;
		
		ajaxSubmit(options: any): any;

		layout(options: any): any;

		colpick(options?: any): any;

		colpickHide(): any;

		idcDataTable(options?: any): any;

		dragscrollable(options: any): any;

		/* wrapped plugins - END */
}

interface JQueryStatic {
		layout: any;

		fileDownload: any;

		pnotify: any;

		sha256(input: string): string;

		connection: any;
}