using Microsoft.EntityFrameworkCore;
using MyIntroduce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("users")
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Project>()
                .ToTable("projects")
                .HasKey(u => u.ProjectID);

            modelBuilder.Entity<Introduce>()
                .ToTable("introduces")
                .HasKey(h => new { h.UserID, h.Content });

            modelBuilder.Entity<ProjectDetails>()
                .ToTable("projectdetails")
                .HasKey(h => new { h.ProjectID, h.Content });

            modelBuilder.Entity<Skill>()
                .ToTable("skills")
                .HasKey(h => new { h.UserID, h.Content });

            modelBuilder.Entity<Summary>()
                .ToTable("summarys")
                .HasKey(h => new { h.UserID, h.Content });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Introduce> Introduces { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Summary> Summarys { get; set; }
    }
}
