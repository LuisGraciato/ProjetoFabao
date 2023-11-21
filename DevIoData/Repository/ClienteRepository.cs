using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MyDbContext _dbContext;

        public ClienteRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            _dbContext.Entry(cliente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}