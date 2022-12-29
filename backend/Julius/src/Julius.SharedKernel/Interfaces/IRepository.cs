using Ardalis.Specification;

namespace Julius.SharedKernel.Interfaces;
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}


