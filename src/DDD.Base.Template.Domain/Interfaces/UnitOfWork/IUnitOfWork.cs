using System.Threading.Tasks;

namespace DDD.Base.Template.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
