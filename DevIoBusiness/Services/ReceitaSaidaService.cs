using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class ReceitaSaidaService : IReceitaSaidaService
    {
        private readonly IReceitaSaidaRepository _receitaSaidaRepository;

        public ReceitaSaidaService(IReceitaSaidaRepository receitaSaidaRepository)
        {
            _receitaSaidaRepository = receitaSaidaRepository;
        }

        public async Task<IEnumerable<ReceitaSaida>> GetAllReceitasSaida()
        {
            return await _receitaSaidaRepository.GetAllReceitasSaida();
        }

        public async Task<ReceitaSaida> GetReceitaSaidaById(int id)
        {
            return await _receitaSaidaRepository.GetReceitaSaidaById(id);
        }

        public async Task<IEnumerable<ReceitaSaida>> GetReceitasSaidaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await _receitaSaidaRepository.GetReceitasSaidaPorPeriodo(dataInicio, dataFim);
        }

        public async Task<ReceitaSaida> AddReceitaSaida(ReceitaSaida receitaSaida)
        {
            return await _receitaSaidaRepository.AddReceitaSaida(receitaSaida);
        }

        public async Task<ReceitaSaida> UpdateReceitaSaida(ReceitaSaida receitaSaida)
        {
            return await _receitaSaidaRepository.UpdateReceitaSaida(receitaSaida);
        }

        public async Task<bool> DeleteReceitaSaida(int id)
        {
            return await _receitaSaidaRepository.DeleteReceitaSaida(id);
        }
    }
}
