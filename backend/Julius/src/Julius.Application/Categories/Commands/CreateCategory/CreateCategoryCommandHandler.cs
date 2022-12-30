using Julius.Domain.CategoryAggregate;

namespace Julius.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
    {
        public CreateCategoryCommandHandler()
        {

        }

        public Category Handle(Category category)
        {
            return category;
        }
    }
}
