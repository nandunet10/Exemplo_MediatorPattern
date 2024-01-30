namespace Aula83.MediatorPattern.Domain.Cliente.Entity
{
    public class ClienteEntity
    {
        public ClienteEntity(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }







    }
}
