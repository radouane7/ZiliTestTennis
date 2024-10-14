using AutoMapper;
using AutoMapper.Features;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Application.Feature.Dto;
using Tennis.Application.Feature.Queries.GetPlayersSortedByRank;

using Tennis.Domain.Abstractions;
using Tennis.Domain.Entities;
using Tennis.Domain.ValueObjects;
namespace Tennis.Tests
{
    public class GetPlayersSortedByRankQueryHandlerTests
    {
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;
        private readonly IMapper _mapper;
        private readonly GetPlayersSortedByRankQueryHandler _handler;

        public GetPlayersSortedByRankQueryHandlerTests()
        {
            _playerRepositoryMock = new Mock<IPlayerRepository>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TennisPlayer, PlayerDto>();
                cfg.CreateMap<Country, CountryDto>();
                cfg.CreateMap<PlayerData, PlayerDataDto>();
            });
            _mapper = configuration.CreateMapper();
            _handler = new GetPlayersSortedByRankQueryHandler(_playerRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ReturnsPlayersSortedByRank()
        {
            // Arrange
            var players = new List<TennisPlayer>
        {
            new TennisPlayer(1, "Novak", "Djokovic", "N.DJO", "M", new Country ( "SRB",  "" ), "", new PlayerData(2, 2542, 80000, 188, 31, new List<int>{1, 1, 1, 1, 1})),
            new TennisPlayer(2, "Venus", "Williams", "V.WIL", "F", new Country ("USA", ""), "", new PlayerData(52, 1105, 74000, 185, 38, new List<int>{0, 1, 0, 0, 1}))
        };

            _playerRepositoryMock.Setup(repo => repo.GetPlayers()).Returns(players);

            // Act
            var result = await _handler.Handle(new GetPlayersSortedByRankQuery(), CancellationToken.None);

            // Assert
            result.Should().BeOfType<List<PlayerDto>>();
            result.Should().HaveCount(2);
            result.First().Shortname.Should().Be("N.DJO"); // Check if sorted correctly by rank
        }
    }
}
