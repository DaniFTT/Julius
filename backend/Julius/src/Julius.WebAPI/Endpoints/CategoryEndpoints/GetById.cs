using Ardalis.ApiEndpoints;
using Julius.API.Shared;
using Julius.Application.Categories.Queries.GetCategoryById;
using Julius.Domain.CategoryAggregate;
using Julius.WebAPI.Endpoints.CategoryEndpoints;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Julius.API.Endpoints.CategoryEndpoints
{
    public class GetById : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<Category>
    {
        protected readonly IMediator _mediator;
        public GetById(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routes.CategoryUri + "/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
          Summary = "Obter Categoria",
          Description = "Obtem a categoria por Id",
          OperationId = "category.create"
        )]
        public override async Task<ActionResult<Category>> HandleAsync(Guid categoryId,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(categoryId), cancellationToken);

            return result.Handle()
                        .OnSuccess(category => Ok(category))
                        .OnNotFound(r => NotFound())
                        .OnError(errors => BadRequest(result.Errors))
                        .Resolve();
        }
    }
}
