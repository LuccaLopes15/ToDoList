using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Common.Base;
using ToDoList.Shared.Domain.Lists.Entities;

namespace ToDoList.Data.Configurations.Lists;

public class ListConfiguration : EntityConfiguration<List>
{
    public override void Configure(EntityTypeBuilder<List> builder)
    {
        builder.ToTable("Lists");

        builder.Property(list => list.Title)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(list => list.Items)
            .WithOne(item => item.List)
            .HasForeignKey(item => item.ListId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        base.Configure(builder);
    }
}
