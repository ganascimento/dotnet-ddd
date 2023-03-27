namespace SampleProject.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync();
}