using Julius.Application.Abstractions;
using Julius.Domain.CategoryAggregate;


namespace Julius.Application.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid? CategoryId) : IQuery<Category>;
     
