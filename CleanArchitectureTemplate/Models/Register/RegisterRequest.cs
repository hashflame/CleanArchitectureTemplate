using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Web.Models.Register
{
    [ExcludeFromCodeCoverage]
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
