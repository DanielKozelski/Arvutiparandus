using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Arvutiparandus.Models
{
	public class Tellimus
	{
		public int Id { get; set; }

		[Required]
		public string Arvutityyp { get; set; }

		[Required]
		public string Teenused { get; set; }

		[Required]
		public string Klient { get; set; }
		public bool Tehtud { get; set; }
		public bool Makstud { get; set; }
	}
}