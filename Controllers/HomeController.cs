using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotnetsource.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.DashBoard;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.DashBoard;
			return View();
		}

		#region Layout
		public ActionResult BoxLayout() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Layouts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.BoxLayout;
			return View();
		}
		public ActionResult SidebarSmall() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Layouts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SidebarSmall;
			return View();
		}
		public ActionResult SidebarMedium() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Layouts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SidebarMedium;
			return View();
		}
		public ActionResult SidebarFixed() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Layouts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SidebarFixed;
			return View();
		}
		public ActionResult SidebarHorizontalMenu() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Layouts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SidebarHorizontalMenu;
			return View();
		}
		#endregion

		#region UIFeatures

		public ActionResult General() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.General;
			return View();
		}


		public ActionResult CheckBoxAndRadio() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.CheckBoxAndRadio;
			return View();
		}


		public ActionResult Buttons() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Buttons;
			return View();
		}

		public ActionResult Typography() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Typography;
			return View();
		}

		public ActionResult Navs() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Navs;
			return View();
		}

		public ActionResult Colors() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Colors;
			return View();
		}

		public ActionResult Wells() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Wells;
			return View();
		}

		public ActionResult Panels() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Panels;
			return View();
		}

		public ActionResult Tiles() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Tiles;
			return View();
		}

		public ActionResult Icons() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Icons;
			return View();
		}

		public ActionResult FileInput() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FileInput;
			return View();
		}

		#endregion

		#region Plugins
		public ActionResult Modal() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Modal;
			return View();
		}
		public ActionResult DatePicker() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.DatePicker;
			return View();
		}
		public ActionResult DateRangePicker() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.DateRangePicker;
			return View();
		}
		public ActionResult TimePicker() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.TimePicker;
			return View();
		}
		public ActionResult Switch() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Switch;
			return View();
		}
		public ActionResult Select() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Select;
			return View();
		}
		public ActionResult Select2() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Select2;
			return View();
		}
		public ActionResult InputMask() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.InputMask;
			return View();
		}
		public ActionResult DropZoneFileUpload() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.DropZoneFileUpload;
			return View();
		}
		public ActionResult MultipleFileUpload() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.MultipleFileUpload;
			return View();
		}
		public ActionResult BlockUI() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.BlockUI;
			return View();
		}
		public ActionResult PopoverConfirm() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.PopoverConfirm;
			return View();
		}
		public ActionResult Spinner() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Spinner;
			return View();
		}
		public ActionResult Editable() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Editable;
			return View();
		}
		public ActionResult ColorPicker() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.ColorPicker;
			return View();
		}
		public ActionResult Editor() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Editor;
			return View();
		}
		public ActionResult jQueryUISlider() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.jQueryUISlider;
			return View();
		}
		public ActionResult Slider() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Plugins;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Slider;
			return View();
		}
		#endregion

		#region Chart

		public ActionResult FlotChart() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Charts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FlotChart;
			return View();
		}

		public ActionResult MorrisChart() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Charts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.MorrisChart;
			return View();
		}

		public ActionResult C3Chart() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Charts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.C3Chart;
			return View();
		}

		public ActionResult PieChart() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Charts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.PieChart;
			return View();
		}

		#endregion

		#region Forms
		public ActionResult FormControls() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Forms;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FormControls;
			return View();
		}

		public ActionResult FormLayouts() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Forms;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FormLayouts;
			return View();
		}

		public ActionResult FormValidation() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Forms;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FormValidation;
			return View();
		}

		public ActionResult FormExamples() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Forms;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FormExamples;
			return View();
		}

		public ActionResult FormWizard() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Forms;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FormWizard;
			return View();
		}
		#endregion

		#region Table
		public ActionResult Table() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Tables;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Table;
			return View();
		}

		public ActionResult DataTable() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Tables;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.DataTable;
			return View();
		}
		#endregion

		#region Pages
		public ActionResult SignIn() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SignIn;
			return View();
		}

		public ActionResult SignUp() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SignUp;
			return View();
		}

        public ActionResult ForgotPassword()
        {
            ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
            ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.ForgotPassword;
            return View();
        }

		public ActionResult Lock() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Lock;
			return View();
		}

		public ActionResult Page404() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Page404;
			return View();
		}

		public ActionResult Page500() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Page500;
			return View();
		}

		public ActionResult Blank() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Blank;
			return View();
		}

		public ActionResult Calendar() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Calendar;
			return View();
		}

		public ActionResult Timeline() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Timeline;
			return View();
		}

		public ActionResult Search() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Search;
			return View();
		}

		public ActionResult Profile() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Profile;
			return View();
		}

		public ActionResult Inbox() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Inbox;
			return View();
		}

		public ActionResult Invoice() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Pages;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Invoice;
			return View();
		}
		#endregion
	}
}
