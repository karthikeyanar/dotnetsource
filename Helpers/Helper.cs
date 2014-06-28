using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(dotnetsource.Helpers.Common), "Initialize")]
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
		MenuLevels = 9,
	}

	public enum SubMenu {
		DashBoard = 10,

		General = 11,
		Alerts = 12,
		ToolTipAndPopover = 13,
		Dropdowns = 14,
		Buttons = 15,
		Typography = 16,
		Panels = 17,
		Tiles = 18,
		Icons = 19,
		FileInput = 20,

		BoxLayout = 21,
		SidebarClosed = 22,
		SidebarFixed = 23,
		SidebarHorizontalMenu = 48,

		Modal = 24,
		DatePicker = 25,
		DateRangePicker = 26,
		ColorPicker = 27,
		Editor = 28,
		Slider = 29,

		FlotChart = 30,
		MorrisChart = 31,

		FormControls = 32,
		FormComponents = 33,
		FormLayouts = 34,
		FormValidation = 35,

		Table = 36,
		DataTable = 37,

		SignIn = 38,
		SignUp = 39,
		Lock = 40,
		Page404 = 41,
		Page500 = 42,
		Blank = 43,
		Calendar = 44,
		Timeline = 45,
		Inbox = 46,
		Invoice = 47,
		
		 

	}

	public class Menu {

		public string MenuName { get; set; }

		public string MenuURL { get; set; }

		public int TopMenuID { get; set; }

		public int MenuID { get; set; }

		public string IconName { get; set; }

	}

	public class Common {


		public static string SiteName {
			get {
				return "Pepper";
			}
		}

		public static List<Menu> Menus { get; set; }

		public static void Initialize() {

			Menus = new List<Menu>();

			Menus.Add(new Menu { MenuID = (int)TopMenu.DashBoard, MenuName = "DashBoard", MenuURL = "/Home/Index", TopMenuID = 0, IconName = "fa fa-laptop" });
			Menus.Add(new Menu { MenuID = (int)TopMenu.Layouts, MenuName = "Layouts", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-th" });
			Menus.Add(new Menu { MenuID = (int)TopMenu.UIFeatures, MenuName = "UI Features", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-desktop" });
			Menus.Add(new Menu { MenuID = (int)TopMenu.Plugins, MenuName = "Plugins", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-puzzle-piece" });
			Menus.Add(new Menu { MenuID = (int)TopMenu.Charts, MenuName = "Charts", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-image" });
			Menus.Add(new Menu { MenuID = (int)TopMenu.Forms, MenuName = "Forms", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-tasks" });
			Menus.Add(new Menu { MenuID = (int)TopMenu.Tables, MenuName = "Tables", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-table" });
			Menus.Add(new Menu { MenuID = (int)TopMenu.Pages, MenuName = "Pages", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-files-o" });
	 

			Menus.Add(new Menu { MenuID = (int)SubMenu.BoxLayout, TopMenuID = (int)TopMenu.Layouts, MenuName = "Boxed Page", MenuURL = "/Home/BoxLayout" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SidebarClosed, TopMenuID = (int)TopMenu.Layouts, MenuName = "Sidebar Collapse", MenuURL = "/Home/SidebarClosed" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SidebarFixed, TopMenuID = (int)TopMenu.Layouts, MenuName = "Sidebar Fixed", MenuURL = "/Home/SidebarFixed" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SidebarHorizontalMenu, TopMenuID = (int)TopMenu.Layouts, MenuName = "Horizontal & Sidebar Menu", MenuURL = "/Home/SidebarHorizontalMenu" });


			Menus.Add(new Menu { MenuID = (int)SubMenu.General, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "General", MenuURL = "/Home/General" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Alerts, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Alerts", MenuURL = "/Home/Alerts" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.ToolTipAndPopover, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "ToolTip & Popover", MenuURL = "/Home/ToolTipAndPopover" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Dropdowns, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Dropdowns", MenuURL = "/Home/Dropdowns" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Buttons, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Buttons", MenuURL = "/Home/Buttons" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Typography, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Typography", MenuURL = "/Home/Typography" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Panels, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Panels", MenuURL = "/Home/Panels" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Tiles, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Tiles", MenuURL = "/Home/Tiles" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Icons, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Icons", MenuURL = "/Home/Icons" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FileInput, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "File Input", MenuURL = "/Home/FileInput" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.Modal, TopMenuID = (int)TopMenu.Plugins, MenuName = "Modal", MenuURL = "/Home/Modal" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.DatePicker, TopMenuID = (int)TopMenu.Plugins, MenuName = "Date Picker", MenuURL = "/Home/DatePicker" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.DateRangePicker, TopMenuID = (int)TopMenu.Plugins, MenuName = "Date Range Picker", MenuURL = "/Home/DateRangePicker" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.ColorPicker, TopMenuID = (int)TopMenu.Plugins, MenuName = "Color Picker", MenuURL = "/Home/ColorPicker" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Editor, TopMenuID = (int)TopMenu.Plugins, MenuName = "Editor", MenuURL = "/Home/Editor" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Slider, TopMenuID = (int)TopMenu.Plugins, MenuName = "Slider", MenuURL = "/Home/Slider" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.FlotChart, TopMenuID = (int)TopMenu.Charts, MenuName = "Flot Chart", MenuURL = "/Home/FlotChart" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.MorrisChart, TopMenuID = (int)TopMenu.Charts, MenuName = "Morris Chart", MenuURL = "/Home/MorrisChart" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.FormControls, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Controls", MenuURL = "/Home/FormControls" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FormComponents, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Components", MenuURL = "/Home/FormComponents" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FormLayouts, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Layouts", MenuURL = "/Home/FormLayouts" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FormValidation, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Validation", MenuURL = "/Home/FormValidation" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.Table, TopMenuID = (int)TopMenu.Tables, MenuName = "Table", MenuURL = "/Home/Table" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.DataTable, TopMenuID = (int)TopMenu.Tables, MenuName = "DataTable", MenuURL = "/Home/DataTable" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.SignIn, TopMenuID = (int)TopMenu.Pages, MenuName = "Sign In", MenuURL = "/Home/SignIn" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SignUp, TopMenuID = (int)TopMenu.Pages, MenuName = "Sign Up", MenuURL = "/Home/SignUp" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Lock, TopMenuID = (int)TopMenu.Pages, MenuName = "Lock", MenuURL = "/Home/Lock" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Page404, TopMenuID = (int)TopMenu.Pages, MenuName = "404", MenuURL = "/Home/Page404" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Page500, TopMenuID = (int)TopMenu.Pages, MenuName = "500", MenuURL = "/Home/Page500" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Blank, TopMenuID = (int)TopMenu.Pages, MenuName = "Blank", MenuURL = "/Home/Blank" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Calendar, TopMenuID = (int)TopMenu.Pages, MenuName = "Calendar", MenuURL = "/Home/Calendar" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Timeline, TopMenuID = (int)TopMenu.Pages, MenuName = "Timeline", MenuURL = "/Home/Timeline" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Inbox, TopMenuID = (int)TopMenu.Pages, MenuName = "Inbox", MenuURL = "/Home/Inbox" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Invoice, TopMenuID = (int)TopMenu.Pages, MenuName = "Invoice", MenuURL = "/Home/Invoice" });

		 

			 
		}

		 
	}


}