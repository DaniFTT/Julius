using Julius.SharedKernel;
using Julius.SharedKernel.Interfaces;

namespace Julius.Domain.CategoryAggregate
{
    public class Category : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public string UserId { get; set; }

        public Category(string name, CategoryType type, string userId) : base()
        {
            Name = name;
            Type = type;
            UserId = userId;
        }
    }
}
