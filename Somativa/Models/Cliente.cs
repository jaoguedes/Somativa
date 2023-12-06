using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        [Required(ErrorMessage = "O Campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo Endereço é obrigatório.")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O Campo Telefone é obrigatório.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O Campo CPF é obrigatório.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O Campo E-mail é obrigatório.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Campo Nascimento é obrigatório.")]
        public DateTime Nascimento { get; set; }
        public IEnumerable<Venda>? Venda { get; set; }
    }
}
