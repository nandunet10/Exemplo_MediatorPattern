using Aula83.MediatorPattern.Domain.Cliente.Entity;

namespace Aula83.MediatorPattern.Infra
{
    public class ClienteRepository : IClienteRepository
    {
        public List<ClienteEntity> Clientes { get; }
        public ClienteRepository()
        {
            Clientes = new List<ClienteEntity>();
        }

        public async Task Delete(int id)
        {
            int index = Clientes.FindIndex(x => x.Id == id);
            await Task.Run(() => Clientes.RemoveAt(index));
        }

        public async Task<IEnumerable<ClienteEntity>> GetAll()
        {
            return await Task.FromResult(Clientes);
        }

        public async Task<ClienteEntity> GetById(int id)
        {
            var result = Clientes.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(result);
        }

        public async Task Save(ClienteEntity cliente)
        {
            await Task.Run(() => Clientes.Add(cliente));
        }

        public async Task Update(int id, ClienteEntity cliente)
        {
            int index = Clientes.FindIndex(x => x.Id == id);
            if (index >= 0)
                await Task.Run(() => Clientes[index] = cliente);

        }
    }
}
