using IntuitChallenge.Models;

namespace IntuitChallenge.Services
{
    public interface IClienteService : IGenericService <Cliente>
    {
        Task Update(Cliente cliente);
    }
}
