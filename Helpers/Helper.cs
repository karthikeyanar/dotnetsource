using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotnetsource.Helpers {

	public enum TopMenu {
		DashBoard = 1,
		Layouts = 2,
		UIFeatures = 3,
		Plugins = 4,
		Charts = 5,
		Forms = 6,
		Tables = 7,
		Pages = 8,
		MenuLevels = 9
	}

	public enum SubMenu {
		DashBoard = 1,
		
		General = 2,
		Alerts = 3,
		ToolTipAndPopover = 4,
		Dropdowns = 5,
		Buttons = 6,
		Typography = 7,
		Panels = 8,
		Tiles = 9,
		Icons = 10,
		FileInput = 11,

		BoxLayout = 12,
		SidebarCollapseLayout = 13,
		SidebarFixedLayout = 14,

		Modal = 15,
		DatePicker = 16,
		DateRangePicker = 17,
		ColorPicker = 18,
		Editor = 19,
		Slider = 20,

		FlotChart = 21,
		MorrisChart = 22,

		FormControls = 23,
		FormComponents = 24,
		FormLayouts = 25,
		FormValidation = 26,

		Table = 27,
		DataTable = 28

	}
	 
}