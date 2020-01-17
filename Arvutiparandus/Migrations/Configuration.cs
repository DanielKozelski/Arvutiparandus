namespace Arvutiparandus.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Arvutiparandus.Models.ArvutiparandusDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Arvutiparandus.Models.ArvutiparandusDB context)
        {
        }
    }
}
