using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class Fornecedor
    {        
        public Guid FornecedorId { get; set; }
        [Required(ErrorMessage = "O Campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo CNPJ é obrigatório.")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }
        public IEnumerable<Produto>? Produtos { get; set; }
    }
}
