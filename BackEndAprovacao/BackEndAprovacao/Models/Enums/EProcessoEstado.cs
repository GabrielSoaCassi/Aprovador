using System.ComponentModel;

namespace BackEndAprovacao.Models.Enums
{
    public enum EProcessoEstado
    {
        [Description("Pendente")]
        Pendente,
        [Description("Aprovado")]
        Aprovado,
        [Description("Recusado")]
        Recusado
    }
}