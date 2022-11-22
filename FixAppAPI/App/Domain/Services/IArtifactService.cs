using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Services.Communication;

namespace FixAppAPI.App.Domain.Services;

public interface IArtifactService
{
    Task<IEnumerable<Artifact>> ListAsync();
    Task<IEnumerable<Artifact>> ListByUserIdAsync(int userId);
    Task<ArtifactResponse> SaveAsync(Artifact artifact);
    Task<ArtifactResponse> UpdateAsync(int artifactId,Artifact artifact);
    Task<ArtifactResponse> DeleteAsync(int artifactId);
}
