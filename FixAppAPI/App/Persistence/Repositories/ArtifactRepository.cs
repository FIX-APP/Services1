using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Repositories;
using FixAppAPI.Shared.Persistence.Contexts;
using FixAppAPI.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace FixAppAPI.App.Persistence.Repositories;

public class ArtifactRepository : BaseRepository, IArtifactRepository
{
    public ArtifactRepository(AppDbContext context) : base(context)
    {

    }
    public async Task<IEnumerable<Artifact>> ListAsync()
    {
        return await _context.Artifacts.Include(p=>p.user).ToListAsync();
    }
    public async Task AddAsync(Artifact artifact)
    {
        await _context.Artifacts.AddAsync(artifact);
    }
    public async Task<Artifact> FindByIdAsync(int id)
    {
        return await _context.Artifacts.Include(p=>p.user).FirstOrDefaultAsync(p=>p.id==id);
    }

    public async Task<IEnumerable<Artifact>> FindByUserIdAsync(int id)
    {
        return await _context.Artifacts.Where(p => p.userId == id).Include(p => p.user).ToListAsync();
    }
    public void Update(Artifact artifact)
    {
        _context.Artifacts.Update(artifact);
    }
    public void Remove(Artifact artifact)
    {
        _context.Artifacts.Remove(artifact);
    }

}
