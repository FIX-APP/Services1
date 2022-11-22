using FixAppAPI.App.Domain.Models;

namespace FixAppAPI.App.Domain.Repositories;

public interface IArtifactRepository
{
    Task<IEnumerable<Artifact>> ListAsync();
    Task AddAsync(Artifact artifact);
    Task<Artifact> FindByIdAsync(int artifactId);
    Task<IEnumerable<Artifact>> FindByUserIdAsync(int userId);
    void Update(Artifact artifact);
    void Remove(Artifact artifact);
}
