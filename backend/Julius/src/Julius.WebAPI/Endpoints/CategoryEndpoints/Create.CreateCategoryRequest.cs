using Julius.API.Shared.Request;
using Julius.Application.Categories.Commands.CreateCategory;
using Julius.Domain.CategoryAggregate;
using System.ComponentModel.DataAnnotations;

namespace Julius.WebAPI.Endpoints.CategoryEndpoints
{
    public class CreateCategoryRequest : IApiRequest<CreateCategoryCommand, Category>
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "São permitidos no máximo 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        [Range(0, 1, ErrorMessage = "Escolha um Tipo de Categoria Válida")]
        public int Type { get; set; }

        public CreateCategoryCommand ToCommand()
        {
            return new CreateCategoryCommand { Name = Name, Type = (CategoryType)Type };
        }
    }
}
