using MediatR;
using Tennis.Application.Feature.Dto;

namespace Tennis.Application.Feature.Queries.GetPlayerById
{
    public record GetPlayerByIdQuery(int Id) : IRequest<PlayerDto>;
}
