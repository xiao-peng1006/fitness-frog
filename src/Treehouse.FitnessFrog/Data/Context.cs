using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Data
{
    public class Context : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public Context()
        {
            Database.SetInitializer(new Databaseinitizlizer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Removing the pluralizing table name convention 
            // so our table names will use our entity class singular names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}