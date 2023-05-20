
namespace GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}
