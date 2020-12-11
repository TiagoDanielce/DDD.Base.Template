using FluentValidation.Results;
using MediatR;

namespace DDD.Base.Template.Infra.CrossCutting.Extensions.Mediator.Commands
{
    public abstract class CommandHandler
    {
        protected readonly IMediator _mediator;
        protected readonly INotificationContext _notificationContext;

        protected CommandHandler(IMediator mediator, INotificationContext notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        protected void AddNotification(string message)
            => _notificationContext.AddNotification(new Notification(message));

        protected void AddNotification(string key, string message)
            => _notificationContext.AddNotification(new Notification(key, message));

        protected void AddNotification(ValidationResult validationResult)
            => _notificationContext.AddNotifications(validationResult);

        public bool HasNotifications => _notificationContext.HasNotifications;
    }
}
