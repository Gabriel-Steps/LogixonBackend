using System.Reflection;

namespace LogixonBackend.Application.Services
{
    public class ApplicationAssemblyReference
    {
        public static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
