using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface IReceitaEntradaRepository
    {
        Task<IEnumerable<ReceitaEntrada>> GetAllReceitasEntrada();
        Task<ReceitaEntrada> GetReceitaEntradaById(int id);
        Task<IEnumerable<ReceitaEntrada>> GetReceitasEntradaPorPeriodo(DateTime dataInicio, DateTime dataFim);
        Task<ReceitaEntrada> AddReceitaEntrada(ReceitaEntrada receitaEntrada);
        Task<ReceitaEntrada> UpdateReceitaEntrada(ReceitaEntrada receitaEntrada);
        Task<bool> DeleteReceitaEntrada(int id);
    }
}
