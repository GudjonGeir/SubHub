using SubHub.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SubHub.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SubHub.DAL
{
    public class SubHubContext : DbContext
    {
        public SubHubContext()
            : base("SubHubContext")
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestRating> RequestRatings { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<SubtitleLine> SubtitleLines { get; set; }
        public DbSet<SubtitleRating> SubtitleRatings { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<SubtitleLanguage> MediaLanguages { get; set; }
        public DbSet<MediaGenre> MediaGenres { get; set; }
        //public System.Data.Entity.DbSet<SubHub.Models.ApplicationUser> AspNetUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }



    }
}