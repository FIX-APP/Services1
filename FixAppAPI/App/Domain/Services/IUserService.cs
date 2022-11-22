using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Services.Communication;

namespace FixAppAPI.App.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int userId,User user);
    Task<UserResponse> DeleteAsync(int userId);
}
