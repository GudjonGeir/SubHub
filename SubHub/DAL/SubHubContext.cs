using SubHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SubHub.DAL
{
    public class SubHubContext : DbContext
    {
        public SubHubContext() : base("SubHubContext")
        {
        }

        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Request> Requests { get; set; }
        //public DbSet<RequestRating> RequestRatings { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        //public DbSet<SubtitleLine> SubtitleLines { get; set; }
        //public DbSet<SubtitleRating> SubtitleRatings { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}