using ToDoList.Shared.Domain.Lists.Enums;

namespace ToDoList.Server.Api.Lists.Models.Requests;

public class CreateListRequest
{
    public string Title { get; set; } = string.Empty;
    public ICollection<CreateListItemRequest> Items { get; set; } = [];
    
}

public class CreateListItemRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ItemStatus Status {  get; set; }
}
