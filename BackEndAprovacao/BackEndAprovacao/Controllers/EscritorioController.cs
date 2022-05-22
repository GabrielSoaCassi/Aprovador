using AutoMapper;
using BackEndAprovacao.Dto.EscritorioDto;
using BackEndAprovacao.Models;
using BackEndAprovacao.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndAprovacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscritorioController : Controller
    {
        private readonly IServices<Escritorio> _escritorioService;
        private readonly IMapper _mapper;

        public EscritorioController(IServices<Escritorio> service, IMapper mapper)
        {
            _escritorioService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarEscritorio([FromBody] CreateEscritorioDto escritorioDto)
        {
            var escritorio = _mapper.Map<Escritorio>(escritorioDto);
            try
            {
                _escritorioService.Cadastrar(escritorio);
                return Ok(escritorio);
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult PesquisarEscritorioPorId(int id) => Ok(_escritorioService.Pesquisar(id));

        [HttpGet]
        public IActionResult PesquisarEscritorios()
        {
            return Ok(_escritorioService.PesquisarTodos());
        }

        [HttpPut]
        public IActionResult AtualizarEscritorio([FromBody] Escritorio escritorio)
        {
            try
            {
                _escritorioService.Atualizar(escritorio);
                return Ok(PesquisarEscritorios());
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEscritorio(int id)
        {
            try
            {
                _escritorioService.Remover(id);
                return Ok(PesquisarEscritorios());
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }
    }
}