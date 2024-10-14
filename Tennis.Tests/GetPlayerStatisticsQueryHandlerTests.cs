using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Application.Feature.Dto;
using Tennis.Application.Feature.Queries.GetPlayerById;
using Tennis.Application.Feature.Queries.GetPlayerStatistics;
using Tennis.Domain.Abstractions;
using Tennis.Domain.Entities;
using Tennis.Domain.ValueObjects;

namespace Tennis.Tests
{
    public class GetPlayerStatisticsQueryHandlerTests
    {
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;
        private readonly GetPlayerStatisticsQueryHandler _handler;

        public GetPlayerStatisticsQueryHandlerTests()
        {
            _playerRepositoryMock = new Mock<IPlayerRepository>(); 
            _playerRepositoryMock = new Mock<IPlayerRepository>(); 
            _handler = new GetPlayerStatisticsQueryHandler(_playerRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsCorrectStatistics()
        {
            // Arrange
            var players = new List<TennisPlayer>{
                      new TennisPlayer(1, "Novak", "Djokovic", "N.DJO", "M", new Country("SRB", ""), "",
                                                new PlayerData(2, 2542, 80, 188, 31, new List<int> { 1, 1, 1, 1, 1 })),  
    
                     new TennisPlayer(2, "Venus", "Williams", "V.WIL", "F", new Country("USA", ""), "",
                                                 new PlayerData(52, 1105, 74, 185, 38, new List<int> { 0, 1, 0, 0, 1 }))  
                                                };

            _playerRepositoryMock.Setup(repo => repo.GetPlayers()).Returns(players);

            // Act
            var result = await _handler.Handle(new GetPlayerStatisticsQuery(), CancellationToken.None);

            // Assert
            result.CountryWithHighestWinRatio.Should().Be("SRB");  
            var averageBMI = players.Average(p => p.Data.Weight / Math.Pow(p.Data.Height / 100.0, 2));
            result.AverageBMI.Should().BeApproximately(22.1, 0.05);  
            result.MedianHeight.Should().Be(186.5);  
        }
    }
}
