using FluentAssertions;
using Julius.Application.Categories.Commands.CreateCategory;
using Julius.Domain.CategoryAggregate;
using Julius.Tests.Shared.Builders;
using System.Xml.Linq;

namespace Julius.UnitTests.Application.CategoriesTests.Commands;

public class CreateCategoryCommandTest
{
    [Fact]
    public void CreateCategoryCommandHandler_Handle_Should_Create_Valid_Category()
    {
        // Arrange
        var categoryBuilder = CategoryBuilder.Default();
        var category = categoryBuilder.Build();

        // Act

        var SUT = new CreateCategoryCommandHandler();
        var result = SUT.Handle(category);

        // Assert
        Assert.NotNull(result);
        result.Name.Should().NotBeNullOrEmpty();
        result.Type.Should().NotBeNull();
        result.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void CreateCategoryCommandHandler_Handle_Should_Create_Category()
    {
        // Arrange
        var id = Guid.NewGuid();
        var nome = "Teste";
        var type = CategoryType.Income;

        var categoryBuilder = CategoryBuilder.Default()
            .WithName(nome)
            .WithType(type)
            .WithId(id);

        var category = categoryBuilder.Build();

        // Act

        var SUT = new CreateCategoryCommandHandler();
        var result = SUT.Handle(category);

        // Assert
        Assert.NotNull(result);
        result.Name.Should().NotBeNullOrEmpty();
        result.Type.Should().NotBeNull();
        result.Id.Should().Be(id);
        result.Name.Should().Be(nome);
        result.Type.Should().Be(type);
    }
}

