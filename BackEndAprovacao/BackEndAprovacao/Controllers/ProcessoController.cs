using AutoMapper;
using BackEndAprovacao.Dto.ProcessoDto;
using BackEndAprovacao.Models;
using BackEndAprovacao.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndAprovacao.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ProcessoController : Controller
    {
        private readonly IServices<Processo> _processoService;
        private readonly IMapper _mapper;

        public ProcessoController(IServices<Processo> processo, IMapper mapper)
        {
            _processoService = processo;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarProcesso([FromBody] CreateProcessoDto processoDto)
        {
            var processo = _mapper.Map<Processo>(processoDto);
            try
            {
                _processoService.Cadastrar(processo);
                return Ok(processo);
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        public IActionResult PesquisarProcessos() => Ok(_processoService.PesquisarTodos());

        [HttpGet("{id}")]
        public IActionResult PesquisarPorId(int id)
        {
            try
            {
                return Ok(_processoService.Pesquisar(id));
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpPut]
        public IActionResult AtualizarProcesso([FromBody] UpdateProcessoDTO updateProcessoDto)
        {
            var updateProcesso = _mapper.Map<Processo>(updateProcessoDto);
            try
            {
                return Ok(_processoService.Atualizar(updateProcesso));
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProcesso(int id)
        {
            try
            {
                _processoService.Remover(id);
                return Ok(PesquisarProcessos());
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }
    }
}