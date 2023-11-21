using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class ReceitaSaidaRepository : IReceitaSaidaRepository
    {
        private readonly MyDbContext _dbContext;

        public ReceitaSaidaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReceitaSaida>> GetAllReceitasSaida()
        {
            return await _dbContext.ReceitasSaida.ToListAsync();
        }

        public async Task<ReceitaSaida> GetReceitaSaidaById(int id)
        {
            return await _dbContext.ReceitasSaida.FindAsync(id);
        }

        public async Task<IEnumerable<ReceitaSaida>> GetReceitasSaidaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await _dbContext.ReceitasSaida
                .Where(receita => receita.DataSaida >= dataInicio && receita.DataSaida <= dataFim)
                .ToListAsync();
        }

        public async Task<ReceitaSaida> AddReceitaSaida(ReceitaSaida receitaSaida)
        {
            _dbContext.ReceitasSaida.Add(receitaSaida);
            await _dbContext.SaveChangesAsync();
            return receitaSaida;
        }

        public async Task<ReceitaSaida> UpdateReceitaSaida(ReceitaSaida receitaSaida)
        {
            _dbContext.Entry(receitaSaida).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return receitaSaida;
        }

        public async Task<bool> DeleteReceitaSaida(int id)
        {
            var receitaSaida = await _dbContext.ReceitasSaida.FindAsync(id);
            if (receitaSaida == null)
                return false;

            _dbContext.ReceitasSaida.Remove(receitaSaida);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
