﻿using BackEndAprovacao.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEndAprovacao.Dto.ProcessoDto
{
    public class ReadProcessoDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 20, ErrorMessage = "Verifique se o numero do processo foi digitado corretamente")]
        public string NumeroDeProcesso { get; set; }
        [Required]
        public double ValorCausa { get; set; }
        public Reclamante Reclamante { get; set; }
        public Escritorio Escritorio { get; set; }
    }
}