using ToDoList.Shared.Domain.Lists.Enums;

namespace ToDoList.Server.Api.Lists.Models.Responses;

public class ListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<ItemListResponse> Items { get; set; } = [];

    public static ListResponse FromDto(ListDto dto)
    {
        return new ListResponse
        {
            Id = dto.Id,
            Title = dto.Title,
            Items = dto.Items
        };
    }
}

public class ItemListResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid ListId { get; set; }
    public ItemStatus Status { get; set; }
}
