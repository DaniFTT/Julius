using System.Reflection;

namespace Julius.SharedKernel;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
