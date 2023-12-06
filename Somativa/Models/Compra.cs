using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class Compra
    {
        public Guid CompraId { get; set; }
        [Required(ErrorMessage = "O Campo Nota Fiscal é obrigatório.")]
        [DisplayName("Nota Fiscal")]
        public int Nota { get; set; }
        [Required(ErrorMessage = "O Campo Data e Hora é obrigatório.")]
        [DisplayName("Data e hora")]
        public DateTime DataHora { get; set; }
        public IEnumerable<CompraItem>? CompraItems { get; set; }
    }
}
