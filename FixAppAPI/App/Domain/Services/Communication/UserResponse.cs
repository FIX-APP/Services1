using FixAppAPI.App.Domain.Models;
using FixAppAPI.Shared.Domain.Services.Communication;

namespace FixAppAPI.App.Domain.Services.Communication;

public class UserResponse:BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {

    }
    public UserResponse(User resource) : base(resource)
    {

    }
}
