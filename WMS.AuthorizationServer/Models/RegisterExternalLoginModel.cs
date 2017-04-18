using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Web.Security;

namespace WMS.AuthorizationServer.Models
{
		public class RegisterExternalLoginModel
		{
				[Required]
				[Display(Name = "User name")]
				public string UserName { get; set; }

				public string ExternalLoginData { get; set; }
		}
}