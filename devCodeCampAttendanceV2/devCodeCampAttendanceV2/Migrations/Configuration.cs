namespace devCodeCampAttendanceV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<devCodeCampAttendanceV2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(devCodeCampAttendanceV2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Students.AddOrUpdate(
                s => s.FirstName,
                new Models.Student { FirstName = "test", LastName = "test" });

            context.Classes.AddOrUpdate(c => c.ID,
                new Models.Class { ID = 1, Name = "copper", StartDate = Convert.ToDateTime("2017-11-20"), EndDate = Convert.ToDateTime("2018-03-06") },
                new Models.Class { ID = 2, Name = "germanium", StartDate = Convert.ToDateTime("2018-02-26"), EndDate = Convert.ToDateTime("2018-05-31") }
                );

            context.Instructors.AddOrUpdate(i => i.ID,
                new Models.Instructor { ID = 1, FirstName = "Micheal", LastName = "Heinisch" },
                new Models.Instructor { ID = 2, FirstName = "Andrew", LastName = "Andrew" },
                new Models.Instructor { ID = 3, FirstName = "Wade", LastName = "Carlson" }
                );
        }
    }
}