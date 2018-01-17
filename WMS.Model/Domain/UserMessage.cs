using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Model.Enum;

namespace WMS.Model.Domain
{
		public class UserMessage
		{
				public virtual Guid Id { get; set; }

				public virtual string Message { get; set; }

				public virtual UserMessageType Type { get; set; }

				public virtual bool Checked { get; set; }

				public virtual string From { get; set; }

				public virtual string To { get; set; }

				public virtual DateTime? CreatedAt { get; set; }
		}
}
