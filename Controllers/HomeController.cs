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
		public ActionResult SidebarCollapseLayout() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Layouts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SidebarCollapseLayout;
			return View();
		}
		public ActionResult SidebarFixedLayout() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Layouts;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.SidebarFixedLayout;
			return View();
		}
		#endregion

		#region UIFeatures

		public ActionResult General() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.General;
			return View();
		}

		public ActionResult Alerts() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Alerts;
			return View();
		}

		public ActionResult ToolTipAndPopover() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.ToolTipAndPopover;
			return View();
		}

		public ActionResult Dropdowns() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.UIFeatures;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.Dropdowns;
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

		#endregion

		#region Forms
		public ActionResult FormControls() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Forms;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FormControls;
			return View();
		}

		public ActionResult FormComponents() {
			ViewBag.TopMenu = dotnetsource.Helpers.TopMenu.Forms;
			ViewBag.SubMenu = dotnetsource.Helpers.SubMenu.FormComponents;
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
	}
}
