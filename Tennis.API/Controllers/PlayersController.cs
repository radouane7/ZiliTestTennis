using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tennis.Application.Feature.Queries.GetPlayerById;
using Tennis.Application.Feature.Queries.GetPlayersSortedByRank;
using Tennis.Application.Feature.Queries.GetPlayerStatistics;

namespace Tennis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPlayersSortedByRank")]
        public async Task<IActionResult> GetAllPlayers()
        {
            // Utiliser le médiateur pour envoyer la requête et obtenir les DTOs
            var players = await _mediator.Send(new GetPlayersSortedByRankQuery());
            return Ok(players);
        }

        [HttpGet("GetPlayerById/{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            // Utiliser le médiateur pour envoyer la requête et obtenir le DTO du joueur
            var player = await _mediator.Send(new GetPlayerByIdQuery(id));
            return Ok(player);

        }

        [HttpGet("GetStatistics")]
        public async Task<IActionResult> GetPlayerStatistics()
        {
            var statistics = await _mediator.Send(new GetPlayerStatisticsQuery());
            return Ok(statistics);
        }
    }
}
