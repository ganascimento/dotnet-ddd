using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Interfaces.Repositories.Base;
using SampleProject.Domain.Models.Base;
using SampleProject.Infra.Data.Context;

namespace SampleProject.Infra.Data.Repositories.Base;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    public Repository(DataContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var model = await _dbSet.FindAsync(id);
        return model;
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public T Create(T model)
    {
        model.CreateAt = DateTime.Now;
        var result = _dbSet.Add(model);
        return result.Entity;
    }

    public T Update(T model)
    {
        model.UpdateAt = DateTime.Now;
        var result = _dbSet.Update(model);
        return result.Entity;
    }

    public void Delete(T model)
    {
        _dbSet.Remove(model);
    }
}