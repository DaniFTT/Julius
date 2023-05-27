using Ardalis.Result;
using Ardalis.Specification;
using Julius.Application.Abstractions;
using Julius.Domain.CategoryAggregate;
using Julius.Domain.CategoryAggregate.Specifications;
using Julius.SharedKernel.Interfaces;
using MediatR;

namespace Julius.Application.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Category>
{
    private readonly IRepository<Category> _repository;

    public CreateCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryAlreadyExists = await _repository.FirstOrDefaultAsync(new CategoryByNameSpec(request.Name!), cancellationToken);
        if (categoryAlreadyExists is not null)
            return Result.Error("Categoria Já existe");

        var category = request.ToDomain("123456");
        await _repository.AddAsync(category, cancellationToken);

        return Result.Success(category);
    }
}

