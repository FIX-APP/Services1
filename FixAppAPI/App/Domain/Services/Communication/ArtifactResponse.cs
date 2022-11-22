using FixAppAPI.App.Domain.Models;
using FixAppAPI.Shared.Domain.Services.Communication;

namespace FixAppAPI.App.Domain.Services.Communication;

public class ArtifactResponse : BaseResponse<Artifact>
{
    public ArtifactResponse(string message) : base(message)
    {

    }
    public ArtifactResponse(Artifact resource) : base(resource)
    {

    }
}
