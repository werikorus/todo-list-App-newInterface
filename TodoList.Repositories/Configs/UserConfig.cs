using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities.Users;

namespace TodoList.Repositories.Configs;

public class UserConfig :  IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasColumnName("Name")
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnName("Email")
            .IsRequired();

        builder.Property(c => c.Password)
            .HasColumnName("Password")
            .IsRequired();

        builder.Property(c => c.DateCreate)
            .HasColumnName("DateCreate")
            .IsRequired();

        builder.Property(c => c.DateUpdate)
            .HasColumnName("DateUpdate")
            .IsRequired();
    }
}