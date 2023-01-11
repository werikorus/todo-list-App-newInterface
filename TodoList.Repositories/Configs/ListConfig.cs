using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities.Lists;

namespace TodoList.Repositories.Configs;

public class ListConfig : IEntityTypeConfiguration<List>
{
    public void Configure(EntityTypeBuilder<List> builder)
    {
        builder.ToTable(nameof(List));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.DescriptionList)
            .HasColumnName("DescriptionList")
            .IsRequired();

        builder.Property(c => c.DateCreate)
            .HasColumnName("DateCreate")
            .IsRequired();

        builder.Property(c => c.DateUpdate)
            .HasColumnName("DateUpdate")
            .IsRequired();
    }
}