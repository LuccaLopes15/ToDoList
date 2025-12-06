using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Server.Domain.Common.Base;

namespace ToDoList.Data.Configurations.Base;

public class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Create)
            .IsRequired();

        builder.Property(e => e.Active)
            .IsRequired();

        builder.Property(e => e.Update)
            .IsRequired(false);
    }
}
