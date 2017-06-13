using System.ComponentModel.DataAnnotations;
using WMS.Model.Resource;

namespace WMS.Model.Enum
{
		public enum AccessType
		{
				[Display(ResourceType = typeof(LocalizedText), Name = "None")]
				None = 0,

				[Display(ResourceType = typeof(LocalizedText), Name = "Read_Access")]
				Read = 1,

				[Display(ResourceType = typeof(LocalizedText), Name = "Writte_Access")]
				Writte = 2,

				[Display(ResourceType = typeof(LocalizedText), Name = "ReadAndWritte_Access")]
				ReadAndWritte = 3,

		}
}
