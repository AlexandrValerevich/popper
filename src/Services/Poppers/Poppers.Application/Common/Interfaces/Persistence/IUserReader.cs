using Poppers.Application.Common.Models;

namespace Poppers.Application.Common.Interfaces;

public interface IUserReader
{
    Task<UserReadOnlyModel> GetUserByEmail(string email);
}