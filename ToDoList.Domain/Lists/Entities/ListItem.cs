using ToDoList.Server.Domain.Common.Base;
using ToDoList.Server.Domain.Common.Exceptions;
using ToDoList.Server.Domain.Common.Validations;
using ToDoList.Server.Domain.Lists.Enums;

namespace ToDoList.Server.Domain.Lists.Entities;

public sealed class ListItem : Entity
{
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public ItemStatus Status { get; private set; }
    public Guid ListId { get; private set; }
    public List? List { get; private set; }

    public ListItem(string title, string? description, Guid ListId)
    {
        SetTitle(title);
        SetDescription(description);
        Status = ItemStatus.Novo;
    }

    public void SetTitle(string title)
    {
        Guard.AgainstNullOrWhiteSpace(title, nameof(Title));
        Guard.Against<DomainException>(title.Length < 3, "O título deve ter no mínimo 3 caracteres.");
        Guard.Against<DomainException>(title.Length > 20, "O título deve ter no máximo 20 caracteres.");

        Title = title.Trim();
    }

    public void SetDescription(string? description)
    {
        if(string.IsNullOrWhiteSpace(description))
        {
            description = null;
        }
        else
        {
            Guard.Against<DomainException>(description.Length < 3, "A descrição deve ter no mínimo 3 caracteres.");
            Guard.Against<DomainException>(description.Length > 200, "A descrição deve ter no máximo 200 caracteres.");

            description = description.Trim();
        }

        Description = description;
    }
}