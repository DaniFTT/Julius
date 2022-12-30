using AutoFixture;
using Julius.Domain.CategoryAggregate;
using Julius.Shared.Tests;
using Julius.SharedKernel;

namespace Julius.Tests.Shared.Builders;

public abstract class BaseEntityBuilder<T> where T : EntityBase
{
    protected T obj;
    private static Fixture _fixture = FixtureContainer.GetFixtureContainer();

    //public BaseEntityBuilder()
    //{
    //    var baseEntity = _fixture.Create<T>();
    //    obj = _fixture.Build<T>().Without(p => p.Id).Create<T>();
    //}
    public BaseEntityBuilder()
    {
        ////_fixture.Customizations.Add(new EntityBaseGenerator<T>(id));

        //Type entityBaseType = typeof(T);
        //Type constructed = entityBaseType.GetType();
        //T? entityBase = Activator.CreateInstance(entityBaseType, id ?? Guid.NewGuid()) as T;

        obj = _fixture.Create<T>();
    }

    /// <summary>
    /// Define o Id da <see cref="Category"/> .
    /// </summary> 
    public BaseEntityBuilder<T> WithId(Guid value)
    {
        obj.Id = value;
        return this;
    }

    /// <summary>
    /// Cria uma Instancia da parcela construida pelos argumentos informados;
    /// </summary>  
    public T Build()
    {
        return obj;
    }
}