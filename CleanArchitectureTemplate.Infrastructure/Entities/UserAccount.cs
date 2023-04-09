using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Infrastructure.Entities
{
    [ExcludeFromCodeCoverage]
    public class UserAccount
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
