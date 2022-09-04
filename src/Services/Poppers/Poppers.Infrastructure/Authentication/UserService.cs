using Microsoft.EntityFrameworkCore;
using Poppers.Application.Common.Interfaces.Authentication;
using Poppers.Application.Common.Models;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace Poppers.Infrastructure.Authentication;

internal sealed class UserService : IUserService
{
    private readonly ReadDbContext _context;

    public UserService(ReadDbContext context)
    {
        _context = context;
    }

    private DbSet<UserReadOnlyModel> Users => _context.Users;

    public async Task<bool> IsExistedUser(string email, CancellationToken cancellationToken)
    {
        return await Users.AnyAsync(u => u.Email.Equals(email), cancellationToken);
    }
}