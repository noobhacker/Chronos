namespace ChronosWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ChronosWebAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ChronosWebAPI.Models.ChronosWebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ChronosWebAPI.Models.ChronosWebAPIContext context)
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
            context.Students.AddOrUpdate(new Student()
            {
                Id = 1,
                Email = "chronosmy@outlook.com",
                FullName = "Developer",
                StudentId = "888888888",
                Password = "Microsoft123",
                DailyConfessionChance=100
            });
        }
    }
}
