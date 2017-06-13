using System.ComponentModel.DataAnnotations;
using WMS.Model.Resource;

namespace WMS.Model.Enum
{
		public enum AuthorizationType
		{
				//[DisplayAttribute(Name = "", Description = "Any description")]
				[Display(ResourceType = typeof(LocalizedText), Name = "None")]
				None = 0,

				[Display(ResourceType = typeof(LocalizedText), Name = "Material")]
				Material = 1,

				[Display(ResourceType = typeof(LocalizedText), Name = "Location")]
				Location = 2,

				[Display(ResourceType = typeof(LocalizedText), Name = "Configuration")]
				Configuration = 3,

				[Display(ResourceType = typeof(LocalizedText), Name = "MaterialLock")]
				MaterialLock = 4,
		}
}
