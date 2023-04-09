using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Core.Exceptions
{
    //Implemented static class with exceptions for better inlining of JIT compiler
    [ExcludeFromCodeCoverage]
    public static class Errors
    {
        public static void InvalidDataException(string message)
        {
            throw new InvalidDataException(message);
        }

        public static void AppException(string message)
        {
            throw new ApplicationException(message);
        }
    }
}
