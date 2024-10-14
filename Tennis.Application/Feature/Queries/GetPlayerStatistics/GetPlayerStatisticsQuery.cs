using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Application.Feature.Dto;

namespace Tennis.Application.Feature.Queries.GetPlayerStatistics
{
    public record GetPlayerStatisticsQuery : IRequest<PlayerStatisticsDto>
    {
    }
}
