using Julius.Infrastructure.Data.DataBaseContext;
using Julius.Infrastructure.IoC.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Julius.Infrastructure.IoC.Installers
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(
                selector => selector
                    .FromAssemblies(
                        Julius.Infrastructure.Data.AssemblyReference.Assembly)
                    .AddClasses(false)
                    .UsingRegistrationStrategy(Scrutor.RegistrationStrategy.Skip)
                    .AsMatchingInterface()
                    .WithScopedLifetime());

            services.AddDbContext<AppDbContext>(
                (sp, optionsBuilder) =>
                {
                    optionsBuilder.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}
