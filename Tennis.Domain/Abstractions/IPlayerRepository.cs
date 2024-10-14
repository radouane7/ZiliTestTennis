using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Domain.Entities;

namespace Tennis.Domain.Abstractions
{
    public interface IPlayerRepository
    {
        List<TennisPlayer> GetPlayers();
        TennisPlayer GetPlayerById(int Id);

    }
}
