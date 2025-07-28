using CodeFirstApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstApp.Data.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(r => new {r.UserId, r.RoleId});

        builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles);

        builder.HasOne(ur => ur.Role).WithMany(r => r.UserRoles);
    }
}