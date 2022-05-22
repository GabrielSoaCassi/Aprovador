using System.ComponentModel.DataAnnotations;

namespace BackEndAprovacao.Dto.ReclamanteDto
{
    public class CreateReclamanteDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome não pode ser nulo")]
        [StringLength(150)]
        public string Nome { get; set; }
    }
}