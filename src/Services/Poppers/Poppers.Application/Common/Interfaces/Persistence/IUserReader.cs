using Poppers.Application.Common.Models;

namespace Poppers.Application.Common.Interfaces;

public interface IUserReader
{
    Task<UserReadOnlyModel> ReadByEmail(string email, CancellationToken token);
    Task<UserReadOnlyModel> ReadById(Guid userId, CancellationToken token);
}