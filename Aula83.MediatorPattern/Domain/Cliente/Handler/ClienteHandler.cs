using Aula83.MediatorPattern.Domain.Cliente.Command;
using Aula83.MediatorPattern.Domain.Cliente.Entity;
using Aula83.MediatorPattern.Infra;
using Aula83.MediatorPattern.Notifications;
using MediatR;

namespace Aula83.MediatorPattern.Domain.Cliente.Handler
{
    public class ClienteHandler :
        IRequestHandler<ClienteCreateCommand, string>,
        IRequestHandler<ClienteUpdateCommand, string>,
        IRequestHandler<ClienteDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IClienteRepository _clienteRepository;

        public ClienteHandler(IMediator mediator, IClienteRepository clienteRepository)
        {
            _mediator = mediator;
            _clienteRepository = clienteRepository;
        }

        public async Task<string> Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            var cliente = new ClienteEntity(request.Id, request.Nome, request.Email, request.Telefone);
            await _clienteRepository.Save(cliente);

            await _mediator.Publish(new ClienteActionNotification
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Action = ActionNotification.Criado
            }, cancellationToken);
            return await Task.FromResult("Cliente criado com Sucesso!");
        }

        public async Task<string> Handle(ClienteUpdateCommand request, CancellationToken cancellationToken)
        {
            var cliente = new ClienteEntity(request.Id, request.Nome, request.Email, request.Telefone);
            await _clienteRepository.Update(cliente.Id, cliente);

            await _mediator.Publish(new ClienteActionNotification
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Action = ActionNotification.Atualizado
            }, cancellationToken);
            return await Task.FromResult("Cliente atualizado com Sucesso!");
        }

        public async Task<string> Handle(ClienteDeleteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetById(request.Id);
            await _clienteRepository.Delete(cliente.Id);

            await _mediator.Publish(new ClienteActionNotification
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Action = ActionNotification.Excluido
            }, cancellationToken);
            return await Task.FromResult("Cliente excluido com Sucesso!");

        }
    }
}
