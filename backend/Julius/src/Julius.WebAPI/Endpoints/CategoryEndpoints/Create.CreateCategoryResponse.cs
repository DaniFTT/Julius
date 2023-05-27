using Ardalis.Result;
using Julius.API.Shared.Response;
using Julius.Application.Categories.Commands.CreateCategory;
using Julius.Domain.CategoryAggregate;

namespace Julius.WebAPI.Endpoints.CategoryEndpoints
{
    public record CreateCategoryResponse
    {
        public string  Id { get; set; }
        public string Name { get; set; }
        public CategoryTypeResponse CategoryType { get; set; }

        public CreateCategoryResponse (Category category)
        {
            Id = category.Id.ToString();
            Name = category.Name;
            CategoryType = new CategoryTypeResponse(category.Type.Value, category.Type.Name);
        }
    }

    public record CategoryTypeResponse(int Id, string Name);
}
