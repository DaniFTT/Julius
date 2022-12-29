using Julius.Domain.CategoryAggregate;

namespace Julius.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
    {
        public CreateCategoryCommandHandler()
        {

        }

        public Category Handle(string name, CategoryType type)
        {
            return new Category(name, type, "12345");
        }
    }
}
