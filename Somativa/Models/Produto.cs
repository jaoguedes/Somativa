using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        [Required(ErrorMessage = "O Campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Campo Estoque é obrigatório.")]
        public int Estoque { get; set; }
        [Required(ErrorMessage = "O Campo Preço é obrigatório.")]
        //[(ErrorMessage = "O Campo deve ser preenchido por um número.")]
        [DisplayName("Preço")]
        public decimal Preco {  get; set; }
        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set;}
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; } 
        public Fornecedor? Fornecedor { get; set; }

        public string? Imagem { get; set; }
    }
}
