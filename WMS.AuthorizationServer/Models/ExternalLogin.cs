using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Globalization;
using System.Web.Security;


namespace WMS.AuthorizationServer.Models
{
		public class ExternalLogin
		{
				public string Provider { get; set; }
				public string ProviderDisplayName { get; set; }
				public string ProviderUserId { get; set; }
		}
}