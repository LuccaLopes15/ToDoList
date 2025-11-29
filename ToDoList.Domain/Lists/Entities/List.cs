using ToDoList.Server.Domain.Common.Base;
using ToDoList.Server.Domain.Common.Exceptions;
using ToDoList.Server.Domain.Common.Validations;

namespace ToDoList.Server.Domain.Lists.Entities;

public sealed class List : Entity
{
    public string Title { get; private set; } = string.Empty;
    public ICollection<ListItem> Items { get; private set; } = [];

    public List(string title)
    {
        SetTitle(title);
    }

    public void SetTitle(string title)
    {
        Guard.AgainstNullOrWhiteSpace(title, nameof(Title));
        Guard.Against<DomainException>(title.Length < 3, "O título deve ter no mínimo 3 caracteres.");
        Guard.Against<DomainException>(title.Length > 20, "O título deve ter no máximo 20 caracteres.");

        Title = title.Trim();
    }

    public void RemoveItem(ListItem item)
    {
        Guard.AgainstNull(Items, nameof(Items));
        Guard.Against<DomainException>(!Items!.Any(x => x.Id == item.Id), "O item não existe na lista.");

        Items!.Remove(item);
    }

    public void AddItem(ListItem item)
    {
        Guard.AgainstNull(Items, nameof(Items));
        Guard.Against<DomainException>(Items.Any(x => x.Id == item.Id), "O item já existe na lista");

        Items.Add(item);
    }
}
