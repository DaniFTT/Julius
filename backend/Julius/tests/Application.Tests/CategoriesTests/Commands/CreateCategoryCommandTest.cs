using FluentAssertions;
using Julius.Application.Categories.Commands.CreateCategory;
using Julius.Domain.CategoryAggregate;

namespace Application.Tests.CategoriesTests.Commands;

public class CreateCategoryCommandTest
{
    [Fact]
    public void CreateCategoryCommandHandler_Handle_Should_Create_Category()
    {
        // Arrange
        var name = "Teste de Categoria";
        var type = CategoryType.Expense;


        // Act
        var SUT = new CreateCategoryCommandHandler();
        var result = SUT.Handle(name, type);

        // Assert
        Assert.NotNull(result);
        result.Name.Should().Be(name);
        result.Type.Should().Be(type);
    }
}

