using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using FinalProjectMovies.Models;

namespace FinalProjectMovies.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<CinemaLocation> CinemaLocation { get; set; }
    }
}
