
using System;
using System.Linq;
using System.Reflection;

namespace Konoma.CrossFit
{
    internal static class TypeLoader
    {
        private static readonly Assembly PlatformAssembly;

        static TypeLoader()
        {
            PlatformAssembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault((candidate) => candidate.FullName.StartsWith("Konoma.CrossFit.", StringComparison.InvariantCulture));
        }

        internal static Type LoadPlatformType(string name, bool throwOnError = true)
        {
            return PlatformAssembly.GetType(name, throwOnError);
        }
    }
}
