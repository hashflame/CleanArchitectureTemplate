using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Core.Features.Register.Models
{
    [ExcludeFromCodeCoverage]
    public class RegisterCommand : IRequest
    {
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
