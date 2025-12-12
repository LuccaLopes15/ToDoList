using MediatR;
using ToDoList.Shared.Domain.Lists.Enums;

namespace ToDoList.Server.Application.Lists.Commands.Create;

public class CreateListCommand : IRequest
{
    public string Title { get; set; } = string.Empty;
    public ICollection<CreatListItemCommand> Items { get; set; } = [];
}

public class CreatListItemCommand
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ItemStatus Status { get; set; } 
}