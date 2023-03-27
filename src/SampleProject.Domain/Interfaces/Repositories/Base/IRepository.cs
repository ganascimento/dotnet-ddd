using SampleProject.Domain.Models.Base;

namespace SampleProject.Domain.Interfaces.Repositories.Base;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    IQueryable<T> GetAll();
    T Create(T model);
    T Update(T model);
    void Delete(T model);
}