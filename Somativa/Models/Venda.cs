using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Somativa.Models
{
    public class Venda
    {
        public Guid VendaId { get; set; }
        [Required(ErrorMessage = "O Campo Nota Fiscal é obrigatório.")]
        [DisplayName("Nota Fiscal")]
        public int Nota { get; set; }
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        [Required(ErrorMessage = "O Campo Data e Hora é obrigatório.")]
        [DisplayName("Data e hora")]
        public DateTime DataHora { get; set; }
        public IEnumerable<VendaItem>? VendaItems { get; set; }
    }
}
