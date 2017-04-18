using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Domain
{
		public class AuthorizationCode
		{
				public virtual string IdClient { get; set; }
				public virtual int IdUser { get; set; }
				public virtual string Code { get; set; }
				public virtual string Redirect_Uri { get; set; }
				public virtual DateTime Expiration { get; set; }
		}
}
