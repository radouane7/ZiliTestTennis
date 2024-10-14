using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Application.Feature.Dto
{
    public record PlayerDataDto(
    int Rank,
    int Points,
    int Weight,
    int Height,
    int Age,
    List<int> Last
);
}