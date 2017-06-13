using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WMS.ServicesCommon.Helpers
{
		public static class Deserialize
		{

				public static object GetObjectFromXML(string path, Type objectType)
				{
						
						string xml = System.IO.File.ReadAllText(path);

						using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
						{
								var serializer = new XmlSerializer(objectType);
								return serializer.Deserialize(memoryStream);
						}
						
				}


				private static string GetPath()
				{
						string codeBase = Assembly.GetExecutingAssembly().CodeBase;
						var uri = new UriBuilder(codeBase);
						string path = Uri.UnescapeDataString(uri.Path);
						return Path.GetDirectoryName(path);
				}

		}
}
