using DuLich.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DuLich.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DuLichContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DuLich.Entity.DuLichContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
