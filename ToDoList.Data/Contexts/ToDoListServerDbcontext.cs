using Microsoft.EntityFrameworkCore;
using ToDoList.Shared.Domain.Lists.Entities;

namespace ToDoList.Data.Contexts;

public class ToDoListServerDbcontext : DbContext
{
    public ToDoListServerDbcontext() {}

    public ToDoListServerDbcontext(DbContextOptions<ToDoListServerDbcontext> contextOptions) : base(contextOptions) { }

    public DbSet<List> Lists { get; set; }
    public DbSet<ListItem> ListsItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

}
