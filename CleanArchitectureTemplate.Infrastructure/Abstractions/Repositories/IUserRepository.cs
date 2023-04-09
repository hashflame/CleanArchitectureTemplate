using CleanArchitectureTemplate.Infrastructure.Entities;

namespace CleanArchitectureTemplate.Infrastructure.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<UserAccount> CreateAsync(UserAccount userAccount);
    }
}
