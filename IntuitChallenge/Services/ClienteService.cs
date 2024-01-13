using AutoMapper;
using IntuitChallenge.Data;
using IntuitChallenge.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace IntuitChallenge.Services
{
    public class ClienteService : GenericService<Cliente>, IClienteService
    {
        private readonly ClientesDbContext _db;
        public ClienteService(ClientesDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(Cliente cliente)
        {
            _db.Update(cliente);
            await Save();
        }
    }
}
