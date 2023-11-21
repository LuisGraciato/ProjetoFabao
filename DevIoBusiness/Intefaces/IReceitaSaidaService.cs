using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface IReceitaSaidaService
    {
        Task<IEnumerable<ReceitaSaida>> GetAllReceitasSaida();
        Task<ReceitaSaida> GetReceitaSaidaById(int id);
        Task<IEnumerable<ReceitaSaida>> GetReceitasSaidaPorPeriodo(DateTime dataInicio, DateTime dataFim);
        Task<ReceitaSaida> AddReceitaSaida(ReceitaSaida receitaSaida);
        Task<ReceitaSaida> UpdateReceitaSaida(ReceitaSaida receitaSaida);
        Task<bool> DeleteReceitaSaida(int id);
    }
}

