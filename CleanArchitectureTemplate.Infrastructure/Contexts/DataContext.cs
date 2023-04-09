using CleanArchitectureTemplate.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Infrastructure.Contexts
{
    [ExcludeFromCodeCoverage]
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
