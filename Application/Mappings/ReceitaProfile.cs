using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ReceitaProfile:Profile
    {
        public ReceitaProfile()
        {
            CreateMap<ReceitaDTO, Receita>().ReverseMap();
        }
    }
}
