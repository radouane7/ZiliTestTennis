using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Application.Feature.Dto
{
    public record PlayerDto(
    int Id,
    string Firstname,
    string Lastname,
    string Shortname,
    string Sex,
    CountryDto Country,
    string Picture,
    PlayerDataDto Data
);
}
