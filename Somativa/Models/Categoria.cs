using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        [Required(ErrorMessage = "O Campo Nome é obrigatório.")]
        public string Nome { get; set; }
        public IEnumerable<Produto>? Produtos { get; set; }
    }
}
