using AutoMapper;
using BackEndAprovacao.Dto.EscritorioDto;
using BackEndAprovacao.Models;

namespace BackEndAprovacao.Profiles
{
    public class EscritorioProfile : Profile
    {
        public EscritorioProfile()
        {
            CreateMap<CreateEscritorioDto, Escritorio>();
            CreateMap<Escritorio, ReadEscritorioDto>();
        }
    }
}