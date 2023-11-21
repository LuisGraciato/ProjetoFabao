namespace DevIoBusiness.Models
{
    public class ReceitaEntrada
    {
        public int Id { get; private set; }
        public DateTime DataEntrada { get; set; }
        public decimal Valor { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ReceitaEntrada()
        {
            DataEntrada = DateTime.Now;
        }
    }
}
