using System.Reflection;

namespace Julius.Infrastructure.Swagger;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}