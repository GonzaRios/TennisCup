using AplicationCore.Context;
using AplicationCore.Entities;
using AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EFCoreRepository : IPlayer
    {
        private readonly PlayersContext _playersContext;

        public EFCoreRepository(PlayersContext playersContext)
        {
            _playersContext = playersContext;
        }

        public Players GetById(int id)
        {
            var players = _playersContext.Players.Find(id);
            return players;
        }

        public List<Players> GetAll()
        {
            var listPlayers = from p in _playersContext.Players
                                 select p;
            return listPlayers.ToList();
        }
        public Players Create(Players players)
        {
            _playersContext.Players.Add(players);
            _playersContext.SaveChanges();
            return players;
        }
        public Players Update(int id, Players players)
        {
            _playersContext.Update(players);
            _playersContext.SaveChanges();
            return players;
        }
    }
}
