using AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Interfaces
{
    public interface ITournamentService
    {
        Task<(MalePlayers? maleChampion, FemalePlayers? femaleChampion)> SimulateTournament(IEnumerable<MalePlayers> malePlayers,
                                    IEnumerable<FemalePlayers> femalePlayers);
        List<Players> GetAllPlayers();
        Task GetPlayersAsync();
        Task UpdateAsync(Players player);
        Task DeleteAsync(int id);
    }
}
