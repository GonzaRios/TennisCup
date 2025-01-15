using AplicationCore.Entities;
using AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlayers.Repositories
{
    public class RepoTest : ITournamentService
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterPlayersAsync(List<Players> players)
        {
            throw new NotImplementedException();
        }

        public Players SimulateTournament(List<Players> players)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Players player)
        {
            throw new NotImplementedException();
        }
    }
}
