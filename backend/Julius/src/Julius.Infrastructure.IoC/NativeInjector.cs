﻿using Julius.Infrastructure.Data.DataBaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Julius.Infrastructure.Data.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using Julius.SharedKernel.Interfaces;
using Julius.SharedKernel;
using MediatR;
using MediatR.Pipeline;
using Autofac;
using System.Reflection;
using Julius.Infrastructure.IoC.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Julius.Infrastructure.IoC.Installers.Api;

namespace Julius.Infrastructure.IoC
{
    public static class NativeInjector
    {    
        public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> servicesInstallers = assemblies
                .SelectMany(a => a.DefinedTypes)
                .Where(typeInfo => typeof(IServiceInstaller).IsAssignableFrom(typeInfo) &&
                    !typeInfo.IsInterface &&
                    !typeInfo.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();


            foreach (IServiceInstaller serviceInstaller in servicesInstallers)
            {
                serviceInstaller.Install(services, configuration);
            }

            return services;
        }

        public static WebApplication UseServices(this WebApplication app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseMiddleware<FakeUserMiddleware>();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseCors(builder => builder
            //    .SetIsOriginAllowed(orign => true)
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.MapControllers();

            return app;
        }
    }
}
