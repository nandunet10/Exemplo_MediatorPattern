using Aula83.MediatorPattern.Domain.Cliente.Command;
using Aula83.MediatorPattern.Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aula83.MediatorPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IMediator mediator, IClienteRepository clienteRepository)
        {
            _mediator = mediator;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteCreateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(ClienteUpdateCommand command)
        {
            return Ok(await _mediator.Send(command));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new ClienteDeleteCommand { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _clienteRepository.GetById(id));
        }
    }
}
