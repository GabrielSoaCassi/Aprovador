using AutoMapper;
using BackEndAprovacao.Dto.ProcessoDto;
using BackEndAprovacao.Models;

namespace BackEndAprovacao.Profiles
{
    public class ProcessoProfile : Profile
    {
        public ProcessoProfile()
        {
            CreateMap<CreateProcessoDto, Processo>();
            CreateMap<Processo, ReadProcessoDto>();
            CreateMap<UpdateProcessoDTO, Processo>();
        }
    }
}