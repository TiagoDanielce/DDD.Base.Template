using DDD.Base.Template.Domain.Interfaces.UnitOfWork;
using System.Threading.Tasks;

namespace DDD.Base.Template.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.TemplateContext _context;
        private readonly INotificationContext _notificationContext;

        public UnitOfWork(Context.TemplateContext context, INotificationContext notificationContext)
        {
            _context = context;
            _notificationContext = notificationContext;
        }

        public async Task BeginTransactionAsync()
            => await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync()
            => await Task.Run(() => _context.Database.CommitTransaction());

        public async Task RollbackTransactionAsync()
            => await Task.Run(() => _context.Database.RollbackTransaction());

        public async Task<bool> SaveChangesAsync()
        {
            if (_notificationContext.HasNotifications)
                return false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
