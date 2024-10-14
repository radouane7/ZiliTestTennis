using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Application.Feature.Dto;
using Tennis.Domain.Entities;
using Tennis.Domain.ValueObjects;

namespace Tennis.Application.Mapping
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            // Mapper TennisPlayer vers PlayerDto
            CreateMap<TennisPlayer, PlayerDto>();

            // Mapper Country vers CountryDto
            CreateMap<Country, CountryDto>();

            // Mapper PlayerData vers PlayerDataDto
            CreateMap<PlayerData, PlayerDataDto>();
        }
    }
}
