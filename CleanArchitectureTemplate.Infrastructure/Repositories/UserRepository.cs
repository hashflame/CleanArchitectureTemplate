using CleanArchitectureTemplate.Core.Exceptions;
using CleanArchitectureTemplate.Infrastructure.Abstractions.Repositories;
using CleanArchitectureTemplate.Infrastructure.Contexts;
using CleanArchitectureTemplate.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
        public async Task<UserAccount> CreateAsync(UserAccount userAccount)
        {
            var checkExistingUsername = await _dataContext.UserAccounts.SingleOrDefaultAsync(x => x.Username == userAccount.Username);
            if (checkExistingUsername != null)
                Errors.AppException("This username already taken.");

            var result = await _dataContext.UserAccounts.AddAsync(userAccount);
            await _dataContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
