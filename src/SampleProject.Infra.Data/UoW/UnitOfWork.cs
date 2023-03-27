using SampleProject.Domain.Interfaces;
using SampleProject.Infra.Data.Context;

namespace SampleProject.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}