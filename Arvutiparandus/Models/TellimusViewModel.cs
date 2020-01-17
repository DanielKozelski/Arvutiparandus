using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arvutiparandus.Models
{
	public class TellimusViewModel
	{
		public string Arvutityyp { get; set; }
		public List<SelectListItem> ArvutityypNimekiri { get; set; }
		public string Teenused { get; set; }
		public List<SelectListItem> TeenusedNimekiri { get; set; }
		public string Klient { get; set; }
	}
}