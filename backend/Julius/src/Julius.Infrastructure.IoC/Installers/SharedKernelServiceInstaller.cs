using Julius.Infrastructure.IoC.Interfaces;
using Julius.SharedKernel.Interfaces;
using Julius.SharedKernel;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Julius.Infrastructure.Data.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace Julius.Infrastructure.IoC.Installers
{
    public class SharedKernelServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
            var sharedAssembly = typeof(SharedKernel.AssemblyReference).Assembly;

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddMediatR(applicationAssembly, sharedAssembly);
        }
    }
}
