using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Dao.Exceptions
{
				[Serializable]
				public class NoActiveTransactionException : Exception
				{
								public NoActiveTransactionException()
												: base("The operation must be performed within a transaction")
								{
								}

								public NoActiveTransactionException(string message) : base(message)
								{
								}

								public NoActiveTransactionException(string message, Exception innerException) : base(message, innerException)
								{
								}

								protected NoActiveTransactionException(SerializationInfo info, StreamingContext context) : base(info, context)
								{
								}
				}
}
