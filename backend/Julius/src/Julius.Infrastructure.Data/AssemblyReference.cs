using System.Reflection;

namespace Julius.Infrastructure.Data;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

