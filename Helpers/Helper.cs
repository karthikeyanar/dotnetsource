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
        CheckBoxAndRadio = 104,
		Buttons = 14,
		Wells = 18,
		Colors = 19,
		Typography = 21,
        Navs = 110,
		Panels = 22,
		Tiles = 23,
		Icons = 24,
		FileInput = 25,
         

		BoxLayout = 26,
		SidebarSmall = 27,
		SidebarMedium = 28,
		SidebarFixed = 29,
		SidebarHorizontalMenu = 30,

		Modal = 31,
		DatePicker = 32,
		DateRangePicker = 33,
		TimePicker = 56,
		Switch = 57,
		Select = 58,
		Select2 = 122,
        InputMask = 120,
        DropZoneFileUpload = 121,
		MultipleFileUpload = 123,
		BlockUI = 130,
		PopoverConfirm = 131,
		Spinner = 59,
		Editable = 60,
		ColorPicker = 34,
		Editor = 35,
		jQueryUISlider = 124,
		Slider = 36,

		

		FlotChart = 37,
		MorrisChart = 38,
		C3Chart = 100,
		PieChart = 150,

		FormControls = 39,
		FormLayouts = 41,
		FormValidation = 42,
		FormExamples = 55,
		FormWizard = 101,

		Table = 43,
		DataTable = 44,

		SignIn = 45,
		SignUp = 46,
        ForgotPassword = 152,
		Lock = 47,
		Page404 = 48,
		Page500 = 49,
		Blank = 50,
		Calendar = 51,
		Timeline = 52,
		Inbox = 53,
		Invoice = 54,
        Search = 140,
		Profile = 151,

        MenuLevel11 = 61,
        MenuLevel12 = 62,
        MenuLevel13 = 63,

        MenuLevel21 = 64,
        MenuLevel22 = 65,
        MenuLevel23 = 66,

        MenuLevel31 = 67,
        MenuLevel32 = 68,
        MenuLevel33 = 69,
         
	}

	public class Menu {

		public string MenuName { get; set; }

		public string MenuURL { get; set; }

		public int TopMenuID { get; set; }

		public int MenuID { get; set; }

		public string IconName { get; set; }

	}

    public class RenderSubMenu
    {
        public int MenuID { get; set; }

        public List<Menu> SubMenus { get; set; }
    }

	public class Common {


		public static string SiteName {
			get {
				return "Fire";
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
            Menus.Add(new Menu { MenuID = (int)TopMenu.MenuLevels, MenuName = "Menu Levels", MenuURL = string.Empty, TopMenuID = 0, IconName = "fa fa-sitemap" });


			Menus.Add(new Menu { MenuID = (int)SubMenu.BoxLayout, TopMenuID = (int)TopMenu.Layouts, MenuName = "Boxed Page", MenuURL = "/Home/BoxLayout" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SidebarMedium, TopMenuID = (int)TopMenu.Layouts, MenuName = "Sidebar Medium", MenuURL = "/Home/SidebarMedium" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SidebarSmall, TopMenuID = (int)TopMenu.Layouts, MenuName = "Sidebar Small", MenuURL = "/Home/SidebarSmall" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SidebarFixed, TopMenuID = (int)TopMenu.Layouts, MenuName = "Sidebar Fixed", MenuURL = "/Home/SidebarFixed" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SidebarHorizontalMenu, TopMenuID = (int)TopMenu.Layouts, MenuName = "Horizontal & Sidebar Menu", MenuURL = "/Home/SidebarHorizontalMenu" });


			Menus.Add(new Menu { MenuID = (int)SubMenu.General, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "General", MenuURL = "/Home/General" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.CheckBoxAndRadio, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "CheckBox & Radio", MenuURL = "/Home/CheckBoxAndRadio" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Buttons, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Buttons", MenuURL = "/Home/Buttons" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.Navs, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Navs", MenuURL = "/Home/Navs" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Typography, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Typography", MenuURL = "/Home/Typography" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.Wells, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Wells", MenuURL = "/Home/Wells" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Panels, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Panels", MenuURL = "/Home/Panels" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Tiles, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Tiles", MenuURL = "/Home/Tiles" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.Colors, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Colors", MenuURL = "/Home/Colors" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.Icons, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "Icons", MenuURL = "/Home/Icons" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FileInput, TopMenuID = (int)TopMenu.UIFeatures, MenuName = "File Input", MenuURL = "/Home/FileInput" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.Modal, TopMenuID = (int)TopMenu.Plugins, MenuName = "Modal", MenuURL = "/Home/Modal" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.DatePicker, TopMenuID = (int)TopMenu.Plugins, MenuName = "Date Picker", MenuURL = "/Home/DatePicker" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.DateRangePicker, TopMenuID = (int)TopMenu.Plugins, MenuName = "Date Range Picker", MenuURL = "/Home/DateRangePicker" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.TimePicker, TopMenuID = (int)TopMenu.Plugins, MenuName = "Time Picker", MenuURL = "/Home/TimePicker" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Switch, TopMenuID = (int)TopMenu.Plugins, MenuName = "Switch", MenuURL = "/Home/Switch" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Select, TopMenuID = (int)TopMenu.Plugins, MenuName = "Select", MenuURL = "/Home/Select" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Select2, TopMenuID = (int)TopMenu.Plugins, MenuName = "Select2", MenuURL = "/Home/Select2" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.InputMask, TopMenuID = (int)TopMenu.Plugins, MenuName = "Input Mask", MenuURL = "/Home/InputMask" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.DropZoneFileUpload, TopMenuID = (int)TopMenu.Plugins, MenuName = "DropZone File Upload", MenuURL = "/Home/DropZoneFileUpload" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.MultipleFileUpload, TopMenuID = (int)TopMenu.Plugins, MenuName = "Multiple File Upload", MenuURL = "/Home/MultipleFileUpload" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.BlockUI, TopMenuID = (int)TopMenu.Plugins, MenuName = "Block UI", MenuURL = "/Home/BlockUI" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.PopoverConfirm, TopMenuID = (int)TopMenu.Plugins, MenuName = "Popover Confirm", MenuURL = "/Home/PopoverConfirm" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Spinner, TopMenuID = (int)TopMenu.Plugins, MenuName = "Spinner", MenuURL = "/Home/Spinner" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Editable, TopMenuID = (int)TopMenu.Plugins, MenuName = "Editable", MenuURL = "/Home/Editable" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.ColorPicker, TopMenuID = (int)TopMenu.Plugins, MenuName = "Color Picker", MenuURL = "/Home/ColorPicker" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Editor, TopMenuID = (int)TopMenu.Plugins, MenuName = "Editor", MenuURL = "/Home/Editor" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.jQueryUISlider, TopMenuID = (int)TopMenu.Plugins, MenuName = "jQuery UI Slider", MenuURL = "/Home/jQueryUISlider" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Slider, TopMenuID = (int)TopMenu.Plugins, MenuName = "Slider", MenuURL = "/Home/Slider" });


			Menus.Add(new Menu { MenuID = (int)SubMenu.FlotChart, TopMenuID = (int)TopMenu.Charts, MenuName = "Flot Chart", MenuURL = "/Home/FlotChart" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.MorrisChart, TopMenuID = (int)TopMenu.Charts, MenuName = "Morris Chart", MenuURL = "/Home/MorrisChart" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.C3Chart, TopMenuID = (int)TopMenu.Charts, MenuName = "C3 Chart", MenuURL = "/Home/C3Chart" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.PieChart, TopMenuID = (int)TopMenu.Charts, MenuName = "Pie Chart", MenuURL = "/Home/PieChart" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.FormControls, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Controls", MenuURL = "/Home/FormControls" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FormLayouts, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Layouts", MenuURL = "/Home/FormLayouts" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FormValidation, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Validation", MenuURL = "/Home/FormValidation" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FormExamples, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Examples", MenuURL = "/Home/FormExamples" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.FormWizard, TopMenuID = (int)TopMenu.Forms, MenuName = "Form Wizard", MenuURL = "/Home/FormWizard" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.Table, TopMenuID = (int)TopMenu.Tables, MenuName = "Table", MenuURL = "/Home/Table" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.DataTable, TopMenuID = (int)TopMenu.Tables, MenuName = "DataTable", MenuURL = "/Home/DataTable" });

			Menus.Add(new Menu { MenuID = (int)SubMenu.SignIn, TopMenuID = (int)TopMenu.Pages, MenuName = "Sign In", MenuURL = "/Home/SignIn" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.SignUp, TopMenuID = (int)TopMenu.Pages, MenuName = "Sign Up", MenuURL = "/Home/SignUp" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.ForgotPassword, TopMenuID = (int)TopMenu.Pages, MenuName = "Forgot Password", MenuURL = "/Home/ForgotPassword" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Lock, TopMenuID = (int)TopMenu.Pages, MenuName = "Lock", MenuURL = "/Home/Lock" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Page404, TopMenuID = (int)TopMenu.Pages, MenuName = "404", MenuURL = "/Home/Page404" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Page500, TopMenuID = (int)TopMenu.Pages, MenuName = "500", MenuURL = "/Home/Page500" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Blank, TopMenuID = (int)TopMenu.Pages, MenuName = "Blank", MenuURL = "/Home/Blank" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Calendar, TopMenuID = (int)TopMenu.Pages, MenuName = "Calendar", MenuURL = "/Home/Calendar" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Timeline, TopMenuID = (int)TopMenu.Pages, MenuName = "Timeline", MenuURL = "/Home/Timeline" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.Search, TopMenuID = (int)TopMenu.Pages, MenuName = "Search", MenuURL = "/Home/Search" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Profile, TopMenuID = (int)TopMenu.Pages, MenuName = "Profile", MenuURL = "/Home/Profile" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Inbox, TopMenuID = (int)TopMenu.Pages, MenuName = "Inbox", MenuURL = "/Home/Inbox" });
			Menus.Add(new Menu { MenuID = (int)SubMenu.Invoice, TopMenuID = (int)TopMenu.Pages, MenuName = "Invoice", MenuURL = "/Home/Invoice" });
            
            
            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel11, TopMenuID = (int)TopMenu.MenuLevels, MenuName = "Menu Level 1.1", MenuURL = "#" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel12, TopMenuID = (int)TopMenu.MenuLevels, MenuName = "Menu Level 1.2", MenuURL = "#" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel13, TopMenuID = (int)TopMenu.MenuLevels, MenuName = "Menu Level 1.3", MenuURL = "#" });

            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel21, TopMenuID = (int)SubMenu.MenuLevel13, MenuName = "Menu Level 2.1", MenuURL = "#" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel22, TopMenuID = (int)SubMenu.MenuLevel13, MenuName = "Menu Level 2.2", MenuURL = "#" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel23, TopMenuID = (int)SubMenu.MenuLevel13, MenuName = "Menu Level 2.3", MenuURL = "#" });

            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel31, TopMenuID = (int)SubMenu.MenuLevel22, MenuName = "Menu Level 3.1", MenuURL = "#" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel32, TopMenuID = (int)SubMenu.MenuLevel22, MenuName = "Menu Level 3.2", MenuURL = "#" });
            Menus.Add(new Menu { MenuID = (int)SubMenu.MenuLevel33, TopMenuID = (int)SubMenu.MenuLevel22, MenuName = "Menu Level 3.3", MenuURL = "#" });

		}


	}


}