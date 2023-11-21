namespace DevIoBusiness.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public Cliente()
        {

        }
    }
}
