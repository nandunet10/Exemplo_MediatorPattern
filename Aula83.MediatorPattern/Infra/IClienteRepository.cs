using Aula83.MediatorPattern.Domain.Cliente.Entity;

namespace Aula83.MediatorPattern.Infra
{
    public interface IClienteRepository
    {
        Task Save(ClienteEntity cliente);
        Task Update(int id, ClienteEntity cliente);
        Task Delete(int id);
        Task<IEnumerable<ClienteEntity>> GetAll();
        Task<ClienteEntity> GetById(int id);
    }
}
