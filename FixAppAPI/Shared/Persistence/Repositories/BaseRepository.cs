using FixAppAPI.Shared.Persistence.Contexts;

namespace FixAppAPI.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}