using System.ComponentModel.DataAnnotations;

namespace BackEndAprovacao.Models
{
    public class Escritorio : EntidadeBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um nome valido")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }
    }
}