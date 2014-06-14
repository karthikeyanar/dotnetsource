using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace dotnetsource.Models {
	public class BreadCrumbModel {
		public string FirstUrl { get; set; }
		public string FirstUrlName { get; set; }
		public string SecondUrl { get; set; }
		public string SecondUrlName { get; set; }
		public string ThirdUrl { get; set; }
		public string ThirdUrlName { get; set; }
	}
}
