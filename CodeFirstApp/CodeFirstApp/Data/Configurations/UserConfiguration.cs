using CodeFirstApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstApp.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id); // Primary Key 


        var name = builder.Property(u => u.Name);
        name.IsRequired();
        name.HasMaxLength(30);

        var surname = builder.Property(u => u.Surname);
        surname.IsRequired();
        surname.HasMaxLength(30);

        var email = builder.Property(u => u.Email);
        email.IsRequired();
        email.HasMaxLength(254);

        var username = builder.Property(u => u.Username);
        username.IsRequired();
        username.HasMaxLength(30);

        builder.Property(u => u.Password).IsRequired();
        
        
    }
}