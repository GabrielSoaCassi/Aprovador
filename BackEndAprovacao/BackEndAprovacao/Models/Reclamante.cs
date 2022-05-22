using System.ComponentModel.DataAnnotations;

namespace BackEndAprovacao.Models
{
    public class Reclamante : EntidadeBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome não pode ser nulo")]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}