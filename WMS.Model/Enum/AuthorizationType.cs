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

				[Display(ResourceType = typeof(LocalizedText), Name = "MaterialLock")]
				MaterialLock = 2,

				[Display(ResourceType = typeof(LocalizedText), Name = "MaterialList")]
				MaterialList = 3,

				[Display(ResourceType = typeof(LocalizedText), Name = "MaterialType")]
				MaterialType = 4,

				[Display(ResourceType = typeof(LocalizedText), Name = "Location")]
				Location = 5,

				[Display(ResourceType = typeof(LocalizedText), Name = "LocationLock")]
				LocationLock = 6,

				[Display(ResourceType = typeof(LocalizedText), Name = "LocationList")]
				LocationList = 7,

				[Display(ResourceType = typeof(LocalizedText), Name = "LocationType")]
				LocationType = 8,

				[Display(ResourceType = typeof(LocalizedText), Name = "Transport")]
				Transport = 9,

				[Display(ResourceType = typeof(LocalizedText), Name = "TransportOrder")]
				TransportOrder = 10,

				[Display(ResourceType = typeof(LocalizedText), Name = "StorageRules")]
				StorageRules = 11,
				
				[Display(ResourceType = typeof(LocalizedText), Name = "TransportMedium")]
				TransportMedium = 12,

				[Display(ResourceType = typeof(LocalizedText), Name = "Configuration")]
				Configuration = 13,

				[Display(ResourceType = typeof(LocalizedText), Name = "User")]
				User = 14,

				[Display(ResourceType = typeof(LocalizedText), Name = "Authorization")]
				Authorization = 15,
				
		}
}
