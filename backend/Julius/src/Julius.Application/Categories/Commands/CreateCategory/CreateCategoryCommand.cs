using Julius.Application.Abstractions;
using Julius.Domain.CategoryAggregate;

namespace Julius.Application.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand : ICommand<Category>
{
    public string? Name { get; set; }
    public CategoryType? Type { get; set; }

    public Category ToDomain(Guid userId) 
    { 
        return new Category(this.Name!, this.Type!, userId);
    }
}

