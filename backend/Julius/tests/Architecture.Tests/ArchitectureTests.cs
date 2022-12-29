using System.Linq;
using System.Reflection;

namespace Architecture.Tests;

public class ArchitectureTests
{
    #region Constants

    private readonly string _webAPINamespace = typeof(Julius.WebAPI.AssemblyReference).Namespace ?? string.Empty;
    private readonly string _applicationNamespace = typeof(Julius.Application.AssemblyReference).Namespace ?? string.Empty;
    private readonly string _domainNamespace = typeof(Julius.Domain.AssemblyReference).Namespace ?? string.Empty;
    private readonly string _infrastructureDataNamespace = typeof(Julius.Infrastructure.Data.AssemblyReference).Namespace ?? string.Empty;
    private readonly string _infrastructureIoCNamespace = typeof(Julius.Infrastructure.IoC.AssemblyReference).Namespace ?? string.Empty;
    private readonly string _infrastructureSwaggerNamespace = typeof(Julius.Infrastructure.Swagger.AssemblyReference).Namespace ?? string.Empty;
    private string[] GetAllProjectsNamespaces() => new[]
    {
        _webAPINamespace, 
        _applicationNamespace, 
        _domainNamespace, 
        _infrastructureDataNamespace,
        _infrastructureIoCNamespace,
        _infrastructureSwaggerNamespace
    };
    private string[] GetNotAllowedProjectsNamespaces(string[] allowedProjectsNamespaces)
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
            _domainNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(domainAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(notAllowedProjectsNamespaces)
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
            _applicationNamespace,
            _domainNamespace,
            _infrastructureDataNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(notAllowedProjectsNamespaces)
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
            _webAPINamespace,
            _applicationNamespace,
            _domainNamespace,
            _infrastructureIoCNamespace,
            _infrastructureSwaggerNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(presentationAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(notAllowedProjectsNamespaces)
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
            _infrastructureDataNamespace,
            _applicationNamespace,
            _domainNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(infrastructureDataAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(notAllowedProjectsNamespaces)
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
            _infrastructureIoCNamespace,
            _infrastructureDataNamespace,
            _applicationNamespace,
            _domainNamespace
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(infrastructureIoCAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureSwagger_Should_Not_HaveDependecyOnOtherProjects()
    {
        // Arrange
        var infrastructureSwaggerAssembly = typeof(Julius.Infrastructure.Swagger.AssemblyReference).Assembly;

        var allowedProjectsNamespaces = new[]
        {
            _infrastructureSwaggerNamespace,
        };

        string[] notAllowedProjectsNamespaces = GetNotAllowedProjectsNamespaces(allowedProjectsNamespaces);

        // Act
        var testResult = Types
            .InAssembly(infrastructureSwaggerAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(notAllowedProjectsNamespaces)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}