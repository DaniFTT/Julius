using Julius.Domain.CategoryAggregate;

namespace Julius.Tests.Shared.Builders;

public class CategoryBuilder : BaseEntityBuilder<Category>
{
    public CategoryBuilder() : base() { }

    /// <summary>
    /// Define o Nome da <see cref="Category"/> .
    /// </summary> 
    public CategoryBuilder WithName(string name)
    {
        obj.Name = name;
        return this;
    }

    /// <summary>
    /// Define o Nome da <see cref="Category"/> .
    /// </summary> 
    public CategoryBuilder WithType(CategoryType type)
    {
        obj.Type = type;
        return this;
    }

    /// <summary>
    /// Define o Nome da <see cref="Category"/> .
    /// </summary> 
    public CategoryBuilder WithUserId(Guid userId)
    {
        obj.DefineUserId(userId);
        return this;
    }

    /// <summary>
    /// Cria uma instância padrão do <see cref="CategoryBuilder"/> .
    /// </summary> 
    public static CategoryBuilder Default()
    {
        return new CategoryBuilder();
    }
}
