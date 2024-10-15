using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Application.Feature.Dto;
using Tennis.Application.Feature.Queries.GetPlayerStatistics;
using Tennis.Domain.Abstractions;

namespace Tennis.Application.Feature.Queries.GetPlayerStatistics

{
    public class GetPlayerStatisticsQueryHandler  : IRequestHandler<GetPlayerStatisticsQuery, PlayerStatisticsDto>

    { 
        private readonly IPlayerRepository _playerRepository; 

        public GetPlayerStatisticsQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Task<PlayerStatisticsDto> Handle(GetPlayerStatisticsQuery request, CancellationToken cancellationToken)
        {
            // Récupérer la liste des joueurs depuis le référentiel
            var players = _playerRepository.GetPlayers();

            // Calculer le nombre total de joueurs
            var totalPlayers = players.Count;

            // Vérifier s'il y a des joueurs dans la base de données
            if (totalPlayers == 0)
            {
                throw new InvalidOperationException("Aucun joueur trouvé.");
            }

            // Calculer le pays avec le plus grand ratio de victoires
            var countryWithHighestWinRatio = players
                .GroupBy(p => p.Country.Code) // Grouper les joueurs par pays
                .Select(group => new
                {
                    Country = group.Key,
                    WinRatio = group.Average(p => p.Data.Last.Count(x => x == 1) / (double)p.Data.Last.Count) // Calcul du ratio de victoires
                })
                .OrderByDescending(g => g.WinRatio) // Trier par ratio décroissant
                .First() // Récupérer le pays avec le meilleur ratio
                .Country;

            // Calculer l'IMC moyen (Indice de Masse Corporelle)
            var averageBMI = players
                .Average(p => p.Data.Weight / Math.Pow(p.Data.Height / 100.0, 2)); // Poids en kg / taille en m² (conversion de la taille en mètres)

            
            // Calculer la médiane de la taille des joueurs
            var heights = players.Select(p => p.Data.Height).OrderBy(h => h).ToList(); // Trier les hauteurs des joueurs

            int N = heights.Count;
            double medianHeight;

            if (N % 2 != 0)
            {
                // Si l'effectif est impair, la médiane est la valeur à la position (N + 1) / 2
                medianHeight = heights[(N + 1) / 2 - 1]; // La position doit être ajustée pour correspondre à l'index 0-based
            }
            else
            {
                // Si l'effectif est pair, la médiane est la moyenne des valeurs aux positions N / 2 et (N / 2) + 1
                medianHeight = (heights[N / 2 - 1] + heights[N / 2]) / 2.0;
            }

            // Retourner les statistiques calculées sous forme de DTO
            return Task.FromResult(new PlayerStatisticsDto
            {
                CountryWithHighestWinRatio = countryWithHighestWinRatio,
                AverageBMI = averageBMI,
                MedianHeight = medianHeight
            });
        }

    }
}






