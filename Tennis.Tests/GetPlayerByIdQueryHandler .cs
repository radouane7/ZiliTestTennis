using AutoMapper;
using FluentAssertions;
using Moq;
using Tennis.Application.Feature.Dto;
using Tennis.Application.Feature.Queries.GetPlayerById;
using Tennis.Domain.Abstractions;
using Tennis.Domain.Entities;
using Tennis.Domain.ValueObjects;

namespace Tennis.Tests
{
    public class GetPlayerByIdQueryHandlerTests
    {
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;
        private readonly IMapper _mapper;
        private readonly GetPlayerByIdQueryHandler _handler;

        public GetPlayerByIdQueryHandlerTests()
        {
            _playerRepositoryMock = new Mock<IPlayerRepository>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TennisPlayer, PlayerDto>();  
                cfg.CreateMap<Country, CountryDto>(); 
                cfg.CreateMap<PlayerData, PlayerDataDto>();
            });
            _mapper = configuration.CreateMapper();

            _handler = new GetPlayerByIdQueryHandler(_playerRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ReturnsPlayer_WhenPlayerExists()
        {
            // Arrange
            var player = new TennisPlayer(1, "Novak", "Djokovic", "N.DJO", "M", new Country("SRB", ""), "", new PlayerData(2, 2542, 80000, 188, 31, new List<int> { 1, 1, 1, 1, 1 }));
            _playerRepositoryMock.Setup(repo => repo.GetPlayerById(1)).Returns(player);

            // Act
            var result = await _handler.Handle(new GetPlayerByIdQuery(1), CancellationToken.None);

            // Assert
            result.Should().BeOfType<PlayerDto>();
            result.Shortname.Should().Be("N.DJO");
        }

        [Fact]
        public async Task Handle_ThrowsKeyNotFoundException_WhenPlayerDoesNotExist()
        {
            // Arrange
            _playerRepositoryMock.Setup(repo => repo.GetPlayerById(99)).Returns((TennisPlayer)null);

            // Act
            var act = async () => await _handler.Handle(new GetPlayerByIdQuery(99), CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
