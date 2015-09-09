using Microsoft.AspNet.Identity.EntityFramework;
//using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineDebateWeb.Models
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OnlineDebateDB : IdentityDbContext<ApplicationUser>
    {
        public OnlineDebateDB()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<OnlineDebateWeb.Models.DebateTopics> DebateTopics { get; set; }

        //public DbSet<ApplicationUser> _ApplicationUser { get; set; }
        //public DbSet<DebateTopics> _DebateTopics { get; set; }
    }
}