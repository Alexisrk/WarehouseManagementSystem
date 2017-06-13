using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WMS.Model.Enum;

namespace WarehouseManagementSystem.Helper
{
		[Serializable, XmlRoot("Menu")]
		public class Menu
		{
				[XmlElement("MenuItem")]
				public List<MenuItem> MenuItems { get; set; }

				public Menu()
				{
						MenuItems = new List<MenuItem>();
				}
		}

		/// <summary>
		/// <MenuItem>
		///			<Text>Menu_Material</Text>
		///			<Icon>None</Icon>
		///			<Authorization>Material</Authorization>
		///			<Action>Index</Action>
		///			<Controller>Material</Controller>
		/// </MenuItem>
		/// </summary>
		public class MenuItem
		{
				[XmlElement(ElementName = "Text")]
				public string Text { get; set; }

				[XmlElement(ElementName = "Icon")]
				public string Icon { get; set; }

				[XmlElement(ElementName = "Authorization")]
				public AuthorizationType? Authorization { get; set; }

				[XmlElement(ElementName = "Controller")]
				public string Controller { get; set; }

				[XmlElement(ElementName = "Action")]
				public string Action { get; set; }

				[XmlElement(ElementName = "Divider")]
				public bool Divider { get; set; }

				[XmlElement("SubItem")]
				public List<MenuItem> SubItems { get; set; }

				public MenuItem()
				{
						SubItems = new List<MenuItem>();
				}
		}

}