using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaskCollection> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Role)
                    .IsRequired()
                    .HasConversion<string>();
            });
            // Configure Team entity
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(u => u.Name).IsUnique();
                entity.Property(u => u.Description).HasMaxLength(500);
            });
            // Configure TaskCollection entity
            modelBuilder.Entity<TaskCollection>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Status).IsRequired().HasConversion<string>(); // Store enum as string
                entity.Property(e => e.DueDate).IsRequired();

                // Define relationships (Foreign Keys)
                // Assuming User and Team are separate entities.
                // You might add navigation properties to the Domain.Task class later
                // if you want to eager/lazy load related entities.
                // For now, we're just handling the FKs.

                // Task has one AssignedToUser
                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(t => t.AssignedToUserId)
                      .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete if user is still assigned to tasks

                // Task has one CreatedByUser
                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(t => t.CreatedByUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Task belongs to one Team
                entity.HasOne<Team>()
                      .WithMany()
                      .HasForeignKey(t => t.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
