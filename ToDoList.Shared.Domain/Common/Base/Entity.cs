namespace ToDoList.Shared.Domain.Common.Base;
public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime Create { get; protected set; }
    public DateTime? Update { get; protected set; }
    public bool Active { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        Create = DateTime.UtcNow;
        Activate();
    }

    protected void SetUpdate()
       => Update = DateTime.UtcNow;

    protected void Activate()
       => Active = true;

    protected void Disable()
       => Active = false;

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
        => Id.GetHashCode();

    public static bool operator ==(Entity left, Entity right)
    {
        if (ReferenceEquals(left, null)) return ReferenceEquals(right, null);

        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}
