using Microsoft.EntityFrameworkCore;
using ToDoList.Server.Domain.Lists.Entities;

namespace ToDoList.Data.Contexts;

public class ToDoListServerDbcontext : DbContext
{
    public ToDoListServerDbcontext() {}

    public ToDoListServerDbcontext(DbContextOptions<ToDoListServerDbcontext> contextOptions) : base(contextOptions) { }

    public DbSet<List> Lists { get; set; }
    public DbSet<ListItem> ListsItems { get; set; }

}
