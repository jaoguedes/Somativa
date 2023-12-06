using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class CompraItem
    {
        public Guid CompraItemId { get; set; }
        [DisplayName("Nota Fiscal")]
        public Guid CompraId { get; set; }
        public Compra? Compra { get; set; }
        [DisplayName("Produto")]
        public Guid ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        [Required(ErrorMessage = "O Campo Quantidade é obrigatório.")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "O Campo Unitário é obrigatório.")]
        [DisplayName("Unitário")]
        public decimal Unitario { get; set; }
    }
}
