using AppConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlutoLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoLibrary
{
    public class PlutoDbContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        private IConfiguration Configuration;

        public PlutoDbContext()
        {
            Configuration = AppConfigurationProvider.BuildConfigurtions();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("PlutoFirstDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CourseTag>()
            .HasKey(ct => new { ct.CourseID, ct.TagID });
            modelBuilder.Entity<CourseTag>()
            .HasOne(ct => ct.Course)
            .WithMany(c => c.Tags)
            .HasForeignKey(ct => ct.CourseID);
            modelBuilder.Entity<CourseTag>()
            .HasOne(ct => ct.Tag)
            .WithMany(t => t.Courses)
            .HasForeignKey(ct => ct.TagID);
        }
    }


}
