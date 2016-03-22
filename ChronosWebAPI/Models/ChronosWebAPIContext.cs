using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChronosWebAPI.Models
{
    public class ChronosWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ChronosWebAPIContext() : base("name=ChronosWebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.Student_Subject> Student_Subject { get; set; }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.SubjectSession> SubjectSessions { get; set; }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.Confession> Confessions { get; set; }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.ConfessionLikes> ConfessionLikes { get; set; }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.PrivateMessage> PrivateMessages { get; set; }

        public System.Data.Entity.DbSet<ChronosWebAPI.Models.MarketItem> MarketItems { get; set; }

    }
}
