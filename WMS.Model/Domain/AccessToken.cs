using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Domain
{
		public class AccessToken
		{
				public virtual Guid Id { get; set; }
				public virtual int IdUser { get; set; }
				public virtual string IdClient { get; set; }
				public virtual string Token { get; set; }
				public virtual string Type { get; set; }
				public virtual DateTime Expiration { get; set; }
				public virtual string RefreshToken { get; set; }
				public virtual string Scope { get; set; }
		}
}
