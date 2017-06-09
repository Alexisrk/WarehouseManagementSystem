using System.ComponentModel.DataAnnotations;
using WMS.Model.Resource;

namespace WMS.Model.Enum
{
		public enum AuthorizationType
		{
				[Display(ResourceType = typeof(LocalizedText), Name = "Material")]
				Material = 1,

				[Display(ResourceType = typeof(LocalizedText), Name = "Location")]
				Location = 2,

				[Display(ResourceType = typeof(LocalizedText), Name = "Configuration")]
				Configuration = 3,

		}
}
