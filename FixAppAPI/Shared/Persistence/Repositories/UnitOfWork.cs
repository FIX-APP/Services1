using FixAppAPI.App.Domain.Repositories;
using FixAppAPI.Shared.Domain.Repositories;
using FixAppAPI.Shared.Persistence.Contexts;

namespace FixAppAPI.Shared.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}