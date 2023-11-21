using System.ComponentModel.DataAnnotations;
using DevIOApi.Attributes;

namespace DevIOApi.ViewModels
{
    public class ReceitaSaidaViewModel
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo Data de Saída é obrigatório.")]
        [DataType(DataType.Date)]
        [CurrentOrPastMonth(ErrorMessage = "A Data de Saída deve ser do mês corrente ou inferior.")]
        public DateTime DataSaida { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor deve ser positivo.")]
        public decimal Valor { get; set; }

        public int ClienteId { get; set; }
    }
}
