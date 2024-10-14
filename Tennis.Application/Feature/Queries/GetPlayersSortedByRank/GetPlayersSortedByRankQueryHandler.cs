using AutoMapper;
using MediatR;
using Tennis.Application.Feature.Dto;

using Tennis.Domain.Abstractions;

namespace Tennis.Application.Feature.Queries.GetPlayersSortedByRank

{
    public class GetPlayersSortedByRankQueryHandler : IRequestHandler<GetPlayersSortedByRankQuery, List<PlayerDto>>
    {

        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public GetPlayersSortedByRankQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public Task<List<PlayerDto>> Handle(GetPlayersSortedByRankQuery request, CancellationToken cancellationToken)
        {
            // Récupérer les joueurs depuis le repository
            var players = _playerRepository.GetPlayers().OrderBy(p => p.Data.Rank).ToList();

            // Utiliser AutoMapper pour mapper les entités vers des DTOs
            var playerDtos = _mapper.Map<List<PlayerDto>>(players);

            return Task.FromResult(playerDtos);
        }
    }
}
