using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Julius.SharedKernel;

public abstract class EntityBase : AuditableEntity, IEquatable<EntityBase>
{
    public Guid Id { get; set; }

    public EntityBase() : base()
    {
        Id = Guid.NewGuid();
    }

    #region Equality Methods

    public static bool operator ==(EntityBase left, EntityBase right)
    {
        return left is not null && right is not null && left.Equals(right);
    }

    public static bool operator !=(EntityBase left, EntityBase right)
    {
        return !(left == right);
    }

    public bool Equals(EntityBase? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        return Id == obj.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not EntityBase entity) return false;

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    #endregion

    #region Domain Events

    private List<DomainEventBase> _domainEvents = new();


    [NotMapped]
    [JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);

    internal void ClearDomainEvents() => _domainEvents.Clear();

    #endregion
}

