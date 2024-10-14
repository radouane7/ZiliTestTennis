using MediatR;
using Tennis.Application.Feature.Dto;

namespace Tennis.Application.Feature.Queries.GetPlayersSortedByRank
{
    public record GetPlayersSortedByRankQuery : IRequest<List<PlayerDto>>;
}
