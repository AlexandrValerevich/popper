using Microsoft.EntityFrameworkCore;
using Poppers.Domain.Entities;
using Poppers.Domain.Interfaces;
using Poppers.Domain.ValueObjects;
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

    public async Task Add(User user)
    {
        await Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(UserId id)
    {
        var user = await ReadById(id);
        Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> ReadAll()
    {
        return await Users.ToListAsync();
    }

    public async Task<User> ReadById(UserId id)
    {
        return await Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task Update(User user)
    {
        Users.Update(user);
        await _context.SaveChangesAsync();
    }
}