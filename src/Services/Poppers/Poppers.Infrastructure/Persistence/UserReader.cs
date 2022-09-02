using Microsoft.EntityFrameworkCore;
using Poppers.Application.Common.Interfaces;
using Poppers.Application.Common.Models;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace Poppers.Infrastructure.Persistence;

internal sealed class UserReader : IUserReader
{
    private readonly ReadDbContext _context;

    private DbSet<UserReadOnlyModel> Users => _context.Users;

    public UserReader(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<UserReadOnlyModel> GetUserByEmail(string email, CancellationToken token)
    {
        return await Users.FirstOrDefaultAsync(u => u.Email.Equals(email), token);
    }
}