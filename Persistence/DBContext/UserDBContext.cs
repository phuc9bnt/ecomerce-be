using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DBContext
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between User and Role
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));

            // Seed Roles
            var adminRoleId = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-123456789012");
            var userRoleId = Guid.Parse("b2c3d4e5-f6a7-8901-bcde-234567890123");
            var moderatorRoleId = Guid.Parse("c3d4e5f6-a7b8-9012-cdef-345678901234");

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = adminRoleId,
                    Name = "Administrator"
                },
                new Role
                {
                    Id = userRoleId,
                    Name = "User"
                },
                new Role
                {
                    Id = moderatorRoleId,
                    Name = "Moderator"
                }
            );

            // Seed Users
            var user1Id = Guid.Parse("d4e5f6a7-b8c9-0123-def4-456789012345");
            var user2Id = Guid.Parse("e5f6a7b8-c9d0-1234-ef45-567890123456");
            var user3Id = Guid.Parse("f6a7b8c9-d0e1-2345-f456-678901234567");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = user1Id,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    UserName = "johndoe",
                    Password = "hashed_password_123" // In production, this should be properly hashed
                },
                new User
                {
                    Id = user2Id,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    UserName = "janesmith",
                    Password = "hashed_password_456" // In production, this should be properly hashed
                },
                new User
                {
                    Id = user3Id,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob.johnson@example.com",
                    UserName = "bobjohnson",
                    Password = "hashed_password_789" // In production, this should be properly hashed
                }
            );

            // Seed User-Role relationships (using the join table)
            modelBuilder.Entity("RoleUser").HasData(
                new { RolesId = adminRoleId, UsersId = user1Id }, // John Doe - Administrator
                new { RolesId = userRoleId, UsersId = user1Id },   // John Doe - User
                new { RolesId = userRoleId, UsersId = user2Id },   // Jane Smith - User
                new { RolesId = moderatorRoleId, UsersId = user3Id }, // Bob Johnson - Moderator
                new { RolesId = userRoleId, UsersId = user3Id }    // Bob Johnson - User
            );
        }
    }
}
