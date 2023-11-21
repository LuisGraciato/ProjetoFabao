using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class ReceitaEntradaRepository : IReceitaEntradaRepository
    {
        private readonly MyDbContext _dbContext;

        public ReceitaEntradaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReceitaEntrada>> GetAllReceitasEntrada()
        {
            return await _dbContext.ReceitasEntrada.ToListAsync();
        }

        public async Task<ReceitaEntrada> GetReceitaEntradaById(int id)
        {
            return await _dbContext.ReceitasEntrada.FindAsync(id);
        }

        public async Task<IEnumerable<ReceitaEntrada>> GetReceitasEntradaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await _dbContext.ReceitasEntrada
                .Where(receita => receita.DataEntrada >= dataInicio && receita.DataEntrada <= dataFim)
                .ToListAsync();
        }


        public async Task<ReceitaEntrada> AddReceitaEntrada(ReceitaEntrada receitaEntrada)
        {
            _dbContext.ReceitasEntrada.Add(receitaEntrada);
            await _dbContext.SaveChangesAsync();
            return receitaEntrada;
        }

        public async Task<ReceitaEntrada> UpdateReceitaEntrada(ReceitaEntrada receitaEntrada)
        {
            _dbContext.Entry(receitaEntrada).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return receitaEntrada;
        }

        public async Task<bool> DeleteReceitaEntrada(int id)
        {
            var receitaEntrada = await _dbContext.ReceitasEntrada.FindAsync(id);
            if (receitaEntrada == null)
                return false;

            _dbContext.ReceitasEntrada.Remove(receitaEntrada);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
