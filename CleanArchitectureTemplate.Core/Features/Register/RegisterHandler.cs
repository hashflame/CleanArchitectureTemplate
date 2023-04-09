using AutoMapper;
using CleanArchitectureTemplate.Core.Features.Register.Models;
using CleanArchitectureTemplate.Infrastructure.Abstractions.Repositories;
using CleanArchitectureTemplate.Infrastructure.Entities;
using MediatR;

namespace CleanArchitectureTemplate.Core.Features.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var userAccount = _mapper.Map<UserAccount>(command);
            var result = await _userRepository.CreateAsync(userAccount);
        }
    }
}
