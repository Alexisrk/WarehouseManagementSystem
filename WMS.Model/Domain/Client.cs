using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Model.Domain
{
		public class Client
		{
				public virtual string Id { get; set; }
				public virtual string Secret { get; set; }
				public virtual string Name { get; set; }
				public virtual string Url { get; set; }
		}
}
