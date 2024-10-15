using Tennis.Domain.Abstractions;
using Tennis.Domain.Entities;
using Tennis.Domain.ValueObjects;

namespace Tennis.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        #region List of Players
        private readonly List<TennisPlayer> _players = new List<TennisPlayer>
    {
        new TennisPlayer(
            52, "Novak", "Djokovic", "N.DJO", "M",
            new Country("SRB", "https://data.latelier.co/training/tennis_stats/resources/Serbie.png"),
            "https://data.latelier.co/training/tennis_stats/resources/Djokovic.png",
            new PlayerData(2, 2542, 80000, 188, 31, new List<int> { 1, 1, 1, 1, 1 })
        ),
        new TennisPlayer(
            95, "Venus", "Williams", "V.WIL", "F",
            new Country("USA", "https://data.latelier.co/training/tennis_stats/resources/USA.png"),
            "https://data.latelier.co/training/tennis_stats/resources/Venus.webp",
            new PlayerData(52, 1105, 74000, 185, 38, new List<int> { 0, 1, 0, 0, 1 })
        ),
        new TennisPlayer(
            65, "Stan", "Wawrinka", "S.WAW", "M",
            new Country("SUI", "https://data.latelier.co/training/tennis_stats/resources/Suisse.png"),
            "https://data.latelier.co/training/tennis_stats/resources/Wawrinka.png",
            new PlayerData(21, 1784, 81000, 183, 33, new List<int> { 1, 1, 1, 0, 1 })
        ),
        new TennisPlayer(
            102, "Serena", "Williams", "S.WIL", "F",
            new Country("USA", "https://data.latelier.co/training/tennis_stats/resources/USA.png"),
            "https://data.latelier.co/training/tennis_stats/resources/Serena.png",
            new PlayerData(10, 3521, 72000, 175, 37, new List<int> { 0, 1, 1, 1, 0 })
        ),
        new TennisPlayer(
            17, "Rafael", "Nadal", "R.NAD", "M",
            new Country("ESP", "https://data.latelier.co/training/tennis_stats/resources/Espagne.png"),
            "https://data.latelier.co/training/tennis_stats/resources/Nadal.png",
            new PlayerData(1, 1982, 85000, 185, 33, new List<int> { 1, 0, 0, 0, 1 })
        )
    };
        #endregion

        public TennisPlayer GetPlayerById(int Id)
        {
            return _players.SingleOrDefault(p => p.Id == Id);
        }

        public List<TennisPlayer> GetPlayers()
        {
            return _players;
        }



    }
}
