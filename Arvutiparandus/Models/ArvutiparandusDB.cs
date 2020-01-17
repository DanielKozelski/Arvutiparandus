using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Arvutiparandus.Models
{
	public class ArvutiparandusDB:DbContext
	{
		public DbSet<Tellimus> Tellimused { get; set; }
	}
}