using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace TheGameNinja.Data
{
    public class TheGameNinjaDbContext : DbContext
    {
        public DbSet<Accolade> Accolades { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match entity names by default (don't pluralize)
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<VideoGame>()
              //          .Property(c => c.Id) // Client must set the ID.
                //        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
