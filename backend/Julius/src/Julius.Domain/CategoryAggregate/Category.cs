using Julius.SharedKernel;
using Julius.SharedKernel.Interfaces;

namespace Julius.Domain.CategoryAggregate;

public class Category : EntityBase, IAggregateRoot
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }

    public Category(string name, CategoryType type, Guid userId) : base(userId)
    {
        Name = name;
        Type = type;
    }
}

