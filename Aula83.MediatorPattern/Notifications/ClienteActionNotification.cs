using MediatR;

namespace Aula83.MediatorPattern.Notifications
{
    public class ClienteActionNotification : INotification
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ActionNotification Action { get; set; }
    }
}
