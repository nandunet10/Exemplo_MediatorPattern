using Aula83.MediatorPattern.Notifications;
using MediatR;

namespace Aula83.MediatorPattern.EventsHandlers
{
    public class EmailHandler : INotificationHandler<ClienteActionNotification>
    {
        public Task Handle(ClienteActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"O cliente {notification.Nome} foi {notification.Action.ToString().ToLower()} com sucesso!");
            });
        }
    }
}
