using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbFirst;

public class AuthDbOctContext : DbContext
{
    public AuthDbOctContext()
    {
    }

    public AuthDbOctContext(DbContextOptions<AuthDbOctContext> options)
        : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var loggerFactory = new LoggerFactory();
        loggerFactory.AddProvider(new MyLoggerProvider());
        optionsBuilder.UseLoggerFactory(loggerFactory);

        optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=AuthDb_Oct; User Id=sa; Password=Elvin123; Trust Server Certificate=True;");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ_Users").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Surname).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(30);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("UserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");
                        j.HasIndex(new[] { "UserId" }, "IX_UserRoles_UserId");
                    });
        });
    }
}
