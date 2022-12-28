using System.Reflection;

namespace Julius.Infrastructure.IoC;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}