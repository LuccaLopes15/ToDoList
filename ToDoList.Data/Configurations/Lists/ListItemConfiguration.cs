using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Common.Base;
using ToDoList.Shared.Domain.Lists.Entities;

namespace ToDoList.Data.Configurations.Lists;

public class ListItemConfiguration : EntityConfiguration<ListItem>
{
    public override void Configure(EntityTypeBuilder<ListItem> builder)
    {
        builder.ToTable("ListsItems");

        builder.Property(listItem => listItem.Title)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(listItem => listItem.Description)
            .IsRequired(false)
            .HasMaxLength(200);

        builder.Property(listItem => listItem.Status)
            .IsRequired();

        base.Configure(builder);
    }
}
