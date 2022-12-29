using System.Linq;
using System.Reflection;

namespace Architecture.Tests;

public class ArchitectureTests
{
    #region Constants

    private const string WebAPINamespace = "Julius.WebAPI";
    private const string ApplicationNamespace = "Julius.Application";
    private const string DomainNamespace = "Julius.Domain";
    private const string InfrastructureDataNamespace = "Julius.Infrastructure.Data";
    private const string InfrastructureIoCNamespace = "Julius.Infrastructure.IoC";
    private const string InfrastructureSwaggerNamespace = "Julius.Infrastructure.Swagger";
    private static string[] GetAllProjectsNamespaces() => new[]
    {
        WebAPINamespace, 
        ApplicationNamespace, 
        DomainNamespace, 
        InfrastructureDataNamespace, 
        InfrastructureIoCNamespace, 
        InfrastructureSwaggerNamespace
    };
    private static string[] GetNotAllowedProjectsNamespaces(string[] allowedProjectsNamespaces)
    {
        return GetAllProjectsNamespaces()
            .Except(allowedProjectsNamespaces)
            .ToArray();
    }

    #endregion

    [Fact]
    public void Domain_Should_Not_HaveDependecyOnOtherProjects()
    {
        // Arrange
        var domainAssembly = typeof(Julius.Domain.AssemblyReference).Assembly;

        var allowedProjectsNamespaces = new[]
        {
            DomainNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(domainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependecyOnOtherProjects()
    {
        // Arrange
        var applicationAssembly = typeof(Julius.Application.AssemblyReference).Assembly;

        var allowedProjectsNamespaces = new[]
        {
            ApplicationNamespace,
            DomainNamespace,
            InfrastructureDataNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependecyOnOtherProjects()
    {
        // Arrange
        var presentationAssembly = typeof(Julius.WebAPI.AssemblyReference).Assembly;

        var allowedProjectsNamespaces = new[]
        {
            WebAPINamespace,
            ApplicationNamespace,
            DomainNamespace,
            InfrastructureIoCNamespace,
            InfrastructureSwaggerNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(presentationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureData_Should_Not_HaveDependecyOnOtherProjects()
    {
        // Arrange
        var infrastructureDataAssembly = typeof(Julius.Infrastructure.Data.AssemblyReference).Assembly;

        var allowedProjectsNamespaces = new[]
        {
            InfrastructureDataNamespace,
            ApplicationNamespace,
            DomainNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(infrastructureDataAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureIoC_Should_Not_HaveDependecyOnOtherProjects()
    {
        // Arrange
        var infrastructureIoCAssembly = typeof(Julius.Infrastructure.IoC.AssemblyReference).Assembly;

        var allowedProjectsNamespaces = new[]
        {
            InfrastructureIoCNamespace,
            InfrastructureDataNamespace,
            ApplicationNamespace,
            DomainNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(infrastructureIoCAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureSwagger_Should_Not_HaveDependecyOnOtherProjects()
    {
        // Arrange
        var infrastructureSwaggerAssembly = typeof(Julius.Infrastructure.Swagger.AssemblyReference).Assembly;

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(Array.Empty<string>());

        // Act
        var testResult = Types
            .InAssembly(infrastructureSwaggerAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}