using CodeFirstApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstApp.Data.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles)
            .HasForeignKey("FK_UserRoles_UserId");
        
        builder.HasOne(ur => ur.Role).WithMany(r => r.UserRoles)
            .HasForeignKey("FK_UserRoles_RoleId");
    }
}