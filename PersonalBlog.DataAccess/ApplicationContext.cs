using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalBlog.DataAccess.Entities;
using PersonalBlog.DataAccess.Identity;
using PersonalBlog.DataAccess.Repositories;

namespace PersonalBlog.DataAccess
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string connectionString) : base(connectionString) { }
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new DbInitializer());
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }      
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

      /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasKey(profile => profile.ApplicationUser);
        }*/
    }

    class DbInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            
            context.Roles.Add(new ApplicationRole() {Name = "admin"});
            context.Roles.Add(new ApplicationRole() {Name = "user" });         
        }
    }

    
}
