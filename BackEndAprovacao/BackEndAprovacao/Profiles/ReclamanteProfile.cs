using AutoMapper;
using BackEndAprovacao.Dto.ReclamanteDto;
using BackEndAprovacao.Models;

namespace BackEndAprovacao.Profiles
{
    public class ReclamanteProfile : Profile
    {
        public ReclamanteProfile()
        {
            CreateMap<CreateReclamanteDto, Reclamante>();
            CreateMap<Reclamante, ReadReclamanteDto>();
        }
    }
}