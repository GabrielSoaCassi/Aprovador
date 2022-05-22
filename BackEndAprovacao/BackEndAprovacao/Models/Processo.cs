using BackEndAprovacao.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BackEndAprovacao.Models
{
    public class Processo : EntidadeBase
    {
        [Required]
        [StringLength(20, MinimumLength = 20, ErrorMessage = "Verifique se o numero do processo foi digitado corretamente")]
        public string NumeroDeProcesso { get; set; }
        public double ValorCausa { get; set; }
        public int ReclamanteId { get; set; }
        public virtual Reclamante Reclamante { get; set; }
        public int EscritorioId { get; set; }
        public virtual Escritorio Escritorio { get; set; }
        public EProcessoEstado EstadoId { get; set; }
        public string Estado => EstadoId.ObterDescricao();
        public bool Ativo { get; set; }

        public Processo()
        {
            EstadoId = EProcessoEstado.Pendente;
        }
    }
}