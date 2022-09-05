using Microsoft.EntityFrameworkCore;
using Poppers.Domain.Entities;
using Poppers.Domain.Interfaces;
using Poppers.Domain.ValueObjects.User;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace Poppers.Infrastructure.Persistence;

internal sealed class UserRepository : IUserRepository
{
    private readonly WriteDbContext _context;

    private DbSet<User> Users => _context.Users;

    public UserRepository(WriteDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user, CancellationToken cancellationToken)
    {
        await Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(UserId id, CancellationToken cancellationToken)
    {
        var user = await ReadById(id, cancellationToken);
        Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<User>> ReadAll(CancellationToken cancellationToken)
    {
        return await Users.ToListAsync(cancellationToken);
    }

    public async Task<User> ReadById(UserId id, CancellationToken cancellationToken)
    {
        return await Users.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task Update(User user, CancellationToken cancellationToken)
    {
        Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}