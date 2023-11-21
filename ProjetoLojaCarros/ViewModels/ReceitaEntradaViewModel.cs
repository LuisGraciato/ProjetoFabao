using DevIOApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class ReceitaEntradaViewModel
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo Data de Entrada é obrigatório.")]
        [DataType(DataType.Date)]
        [CurrentOrPastMonth(ErrorMessage = "A Data de Entrada deve ser do mês corrente ou inferior.")]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor deve ser positivo.")]
        public decimal Valor { get; set; }
        public int ClienteId { get; set; }
    }
}
