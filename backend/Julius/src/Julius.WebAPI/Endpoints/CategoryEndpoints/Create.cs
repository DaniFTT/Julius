using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Julius.API.Shared;
using Julius.API.Shared.Response;
using Julius.Domain.CategoryAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Julius.WebAPI.Endpoints.CategoryEndpoints
{
    public class Create : EndpointBaseAsync
        .WithRequest<CreateCategoryRequest>
        .WithActionResult<CreateCategoryResponse>
    {
        protected readonly IMediator _mediator;
        public Create(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routes.CategoryUri)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCategoryResponse))]
        [SwaggerOperation(
          Summary = "Criar categoria",
          Description = "Realiza a criação de uma categoria",
          OperationId = "category.create"
        )]
        public override async Task<ActionResult<CreateCategoryResponse>> HandleAsync([FromBody] CreateCategoryRequest request,
            CancellationToken cancellationToken = default)
        {   
            var result = await _mediator.Send(request.ToCommand(), cancellationToken);

            return result.Handle()
                        .OnSuccess(r => Created(Routes.CategoryUri, new CreateCategoryResponse(r)))
                        .OnError(errors => BadRequest(result.Errors))
                        .OnInvalid(errors => BadRequest(result.ValidationErrors))
                        .Resolve();
        }
    }

}

