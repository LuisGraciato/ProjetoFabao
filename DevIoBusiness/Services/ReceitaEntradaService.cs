using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class ReceitaEntradaService : IReceitaEntradaService
    {
        private readonly IReceitaEntradaRepository _receitaEntradaRepository;

        public ReceitaEntradaService(IReceitaEntradaRepository receitaEntradaRepository)
        {
            _receitaEntradaRepository = receitaEntradaRepository;
        }

        public async Task<IEnumerable<ReceitaEntrada>> GetAllReceitasEntrada()
        {
            return await _receitaEntradaRepository.GetAllReceitasEntrada();
        }

        public async Task<ReceitaEntrada> GetReceitaEntradaById(int id)
        {
            return await _receitaEntradaRepository.GetReceitaEntradaById(id);
        }

        public async Task<IEnumerable<ReceitaEntrada>> GetReceitasEntradaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await _receitaEntradaRepository.GetReceitasEntradaPorPeriodo(dataInicio, dataFim);
        }


        public async Task<ReceitaEntrada> AddReceitaEntrada(ReceitaEntrada receitaEntrada)
        {
            return await _receitaEntradaRepository.AddReceitaEntrada(receitaEntrada);
        }

        public async Task<ReceitaEntrada> UpdateReceitaEntrada(ReceitaEntrada receitaEntrada)
        {
            return await _receitaEntradaRepository.UpdateReceitaEntrada(receitaEntrada);
        }

        public async Task<bool> DeleteReceitaEntrada(int id)
        {
            return await _receitaEntradaRepository.DeleteReceitaEntrada(id);
        }
    }
}
