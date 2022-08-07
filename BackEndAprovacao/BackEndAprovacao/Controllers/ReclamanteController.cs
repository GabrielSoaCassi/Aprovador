using AutoMapper;
using BackEndAprovacao.Dto.ReclamanteDto;
using BackEndAprovacao.Models;
using BackEndAprovacao.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndAprovacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReclamanteController : Controller
    {
        private readonly IServices<Reclamante> _reclamanteService;
        private readonly IMapper _mapper;

        public ReclamanteController(IServices<Reclamante> service, IMapper mapper)
        {
            _reclamanteService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarReclamante([FromBody] CreateReclamanteDto reclamanteDto)
        {
            var reclamante = _mapper.Map<Reclamante>(reclamanteDto);
            try
            {
                _reclamanteService.Cadastrar(reclamante);
                return Ok(reclamante);
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult PesquisarReclamantePorId([FromRoute]int id)
        {
            return Ok(_reclamanteService.Pesquisar(id));
        }

        [HttpGet]
        public IActionResult PesquisarReclamantes() => Ok(_reclamanteService.PesquisarTodos());

        [HttpPut]
        public IActionResult AtualizarReclamante([FromBody] Reclamante reclamante)
        {
            try
            {
                return Ok(_reclamanteService.Atualizar(reclamante));
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarReclamante(int id)
        {
            try
            {
                _reclamanteService.Remover(id);
                return Ok(PesquisarReclamantes());
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }
    }
}