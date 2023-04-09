using AutoMapper;
using CleanArchitectureTemplate.Core.Features.Register.Models;
using CleanArchitectureTemplate.Infrastructure.Entities;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Core.Features.Register
{
    [ExcludeFromCodeCoverage]
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<UserAccount, RegisterCommand>().ReverseMap();
        }
    }
}
