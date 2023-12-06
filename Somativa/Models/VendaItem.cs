using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class VendaItem
    {
        public Guid VendaItemId { get; set; }
        [DisplayName("Nota Fiscal")]
        public Guid VendaId { get; set; }
        public Venda? Venda { get; set; }
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
