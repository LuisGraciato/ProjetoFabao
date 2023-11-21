using DevIOApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; private set; }

        [MaxLength(255, ErrorMessage = "O campo Nome deve ter no máximo 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date)]
        [AdultAge(ErrorMessage = "O cliente deve ser maior de 18 anos.")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail fornecido não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        public string CPF { get; set; }
    }

}

