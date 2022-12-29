using Ardalis.Specification.EntityFrameworkCore;
using Julius.Infrastructure.Data.DataBaseContext;
using Julius.SharedKernel.Interfaces;

namespace Julius.Infrastructure.Data.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

