﻿using BackEndAprovacao.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BackEndAprovacao.Dto.ProcessoDto
{
    public class UpdateProcessoDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(22, MinimumLength = 22, ErrorMessage = "Verifique se o numero do processo foi digitado corretamente")]
        public string NumeroDeProcesso { get; set; }
        [Required]
        public double ValorCausa { get; set; }
        public int ReclamanteId { get; set; }
        public int EscritorioId { get; set; }
        public EProcessoEstado EstadoId { get; set; }
        public bool Ativo { get; set; }
    }
}