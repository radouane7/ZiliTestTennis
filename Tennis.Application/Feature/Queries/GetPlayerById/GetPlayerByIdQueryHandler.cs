using AutoMapper;
using MediatR;
using Tennis.Application.Feature.Dto;

using Tennis.Domain.Abstractions;

namespace Tennis.Application.Feature.Queries.GetPlayerById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayerDto>

    { 
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
         
        public GetPlayerByIdQueryHandler(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        } 
        public Task<PlayerDto> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            // Récupérer les joueurs depuis le repository
            var player = _playerRepository.GetPlayerById(request.Id);

            // Utiliser AutoMapper pour mapper les entités vers des DTOs
            var playerDto = _mapper.Map<PlayerDto>(player);
            if (playerDto == null)
            {
                // Gérer le cas où le joueur n'est pas trouvé
                throw new KeyNotFoundException($"Player with ID {request.Id} not found.");
            }

            return Task.FromResult(playerDto);
        }
    }
}
