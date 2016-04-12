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
                Email = "chronos@outlook.com",
                FullName = "Chronos",
                StudentId = "888888888",
                Password = "Microsoft123",
                DailyConfessionChance=100
            });

            //context.Students.AddOrUpdate(new Student()
            //{
            //    Id = 2,
            //    Email = "steve@outlook.com",
            //    FullName = "Steve",
            //    StudentId = "888888888",
            //    Password = "Microsoft123",
            //    DailyConfessionChance = 100
            //});

            //context.Students.AddOrUpdate(new Student()
            //{
            //    Id = 3,
            //    Email = "james@outlook.com",
            //    FullName = "James",
            //    StudentId = "888888888",
            //    Password = "Microsoft123",
            //    DailyConfessionChance = 100
            //});

            context.Happenings.AddOrUpdate(new Happening()
            {
                Id = 1,
                ImageUrl = "https://scontent-kul1-1.xx.fbcdn.net/hphotos-xft1/v/t1.0-9/12805907_1022838631107273_79640791752532850_n.jpg?oh=b10492e393aadad17b8913f8e44b4077&oe=575041B4",
                Contact = "012-3456789",
                Description = "IMAGINE CUP!\nIMAGINE CUP!\nIMAGINE CUP!\n",
                StartDateTime = new DateTime(2016, 4, 12),
                EndDateTime = new DateTime(2016, 4, 14),
                Location = "Malacca",
                Name = "Imagine cup Malaysia",
                Price = 0,
                 Organizer="Microsoft",
                 FbUrl= "https://www.facebook.com/myimaginecup"
            });
        }
    }
}
