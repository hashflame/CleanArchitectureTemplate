using AutoMapper;
using CleanArchitectureTemplate.Core.Features.Register.Models;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Web.Models.Register
{
    [ExcludeFromCodeCoverage]
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterRequest, RegisterCommand>();
        }
    }
}
