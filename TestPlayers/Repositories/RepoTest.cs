using AplicationCore.Entities;
using AplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestPlayers.Repositories
{
    public class RepoTest : ITournamentService
    {
        public List<Players> _list;
        public RepoTest()
        {
           
            List<Players> playerList = new List<Players>();
            Players p1 = new Players { Id= 1, Name = "Player1", Gender = "Male", Ability=83 };
            Players p2 = new Players { Id = 2, Name = "Player2", Gender = "Female",  Ability=90 };
            Players p3 = new Players {Id = 3, Name = "Player3", Gender = "Female", Ability = 76 };
            Players p4 = new Players {Id = 4, Name = "Player4", Gender = "Male", Ability = 88 };

            playerList.Add(p1);
            playerList.Add(p2);
            playerList.Add(p3);
            playerList.Add(p4);
            _list = playerList;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Players> GetAllPlayers()
        {
            var playerList = from p in _list
                                 select p;
            return playerList.ToList();
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

        public Task<(MalePlayers? maleChampion, FemalePlayers? femaleChampion)> SimulateTournament(IEnumerable<MalePlayers> malePlayers, IEnumerable<FemalePlayers> femalePlayers)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Players player)
        {
            throw new NotImplementedException();
        }
    }
}
