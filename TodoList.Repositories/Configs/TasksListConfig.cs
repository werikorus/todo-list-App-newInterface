using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities.TasksList;

namespace TodoList.Repositories.Configs;

public class TasksListConfig : IEntityTypeConfiguration<TaskList>
{
    public void Configure(EntityTypeBuilder<TaskList> builder)
    {
        builder.ToTable(nameof(TaskList));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.DescriptionTask)
            .HasColumnName("DescriptionTask")
            .IsRequired();

        builder.Property(c => c.Done)
            .HasColumnName("Done");

        builder.Property(c => c.IdList)
            .HasColumnName("IdList")
            .IsRequired();
        
        builder.Property(c => c.DateCreate)
            .HasColumnName("DateCreate")
            .IsRequired();

        builder.Property(c => c.DateUpdate)
            .HasColumnName("DateUpdate")
            .IsRequired();
    }
}