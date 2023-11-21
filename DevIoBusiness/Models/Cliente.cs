namespace DevIoBusiness.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public List<ReceitaEntrada> ReceitasEntrada { get; set; }
        public List<ReceitaSaida> ReceitasSaida { get; set; }

        public Cliente()
        {
            ReceitasEntrada = new List<ReceitaEntrada>();
            ReceitasSaida = new List<ReceitaSaida>();
        }
    }
}
