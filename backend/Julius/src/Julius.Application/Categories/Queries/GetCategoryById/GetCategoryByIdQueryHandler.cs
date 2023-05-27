using Ardalis.Result;
using Julius.Application.Abstractions;
using Julius.Domain.CategoryAggregate;
using Julius.Domain.CategoryAggregate.Specifications;
using Julius.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Julius.Application.Categories.Queries.GetCategoryById;

internal sealed class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, Category>
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.CategoryId is null)
            return Result.Error("Preencha o Id da Categoria");

        var category = await _repository.FirstOrDefaultAsync(new CategoryByIdSpec(request.CategoryId!.Value), cancellationToken);
        if (category is null)
            return Result.NotFound();

        return Result.Success(category);
    }
}

