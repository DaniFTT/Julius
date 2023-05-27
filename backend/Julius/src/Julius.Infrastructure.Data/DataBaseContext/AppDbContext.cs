using Julius.SharedKernel.Interfaces;
using Julius.SharedKernel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Julius.Domain.CategoryAggregate;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Julius.Infrastructure.Data.DataBaseContext.Config;

namespace Julius.Infrastructure.Data.DataBaseContext;

public class AppDbContext : DbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;
    private readonly IHttpContextAccessor? _httpContextAccessor;

    public AppDbContext() : base() { }

    public AppDbContext(DbContextOptions<AppDbContext> options,
        IDomainEventDispatcher? dispatcher,
        IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        _dispatcher = dispatcher;
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var entityTypes = modelBuilder.Model.GetEntityTypes();
        foreach (var entityType in entityTypes)
        {
            if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
            {
                //Guid userId = (Guid)_httpContextAccessor!.HttpContext.Items["UserId"];
                entityType.AddGlobalQueryFilter(new Guid("89018b18-aad8-4878-b9ef-9584ad77f436"));
            }
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        if (result == 0)
            throw new Exception("An error occurred while trying to save changes");

        if (_dispatcher == null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
