using Ardalis.Specification.EntityFrameworkCore;
using Julius.Infrastructure.Data.DataBaseContext;
using Julius.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Julius.Infrastructure.Data.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    private readonly IHttpContextAccessor? _httpContextAccessor;
    public EfRepository(AppDbContext dbContext, IHttpContextAccessor? httpContextAccessor) : base(dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        //return (Guid)_httpContextAccessor!.HttpContext.Items["UserId"];
        return new Guid("89018b18-aad8-4878-b9ef-9584ad77f436");
    }
}

