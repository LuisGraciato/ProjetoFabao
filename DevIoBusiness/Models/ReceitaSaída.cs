namespace DevIoBusiness.Models
{
    public class ReceitaSaida
    {
        public int Id { get; private set; }
        public DateTime DataSaida { get; set; }
        public decimal Valor { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ReceitaSaida()
        {
            DataSaida = DateTime.Now;
        }
    }
}
