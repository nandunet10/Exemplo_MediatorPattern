using MediatR;

namespace Aula83.MediatorPattern.Domain.Cliente.Command
{
    public class ClienteDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }

    }
}
