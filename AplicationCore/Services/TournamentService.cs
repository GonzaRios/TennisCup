using AplicationCore.Entities;
using AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IPlayerRepository _playerRepository;

        public TournamentService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetPlayersAsync()
        {
            List<Players> lsPlayer = new List<Players>();
            var listPlayer = await _playerRepository.GetAllAsync();
        }

        /// <summary>
        /// Método que registra una lista de jugadores inscriptos en el torneo
        /// si cumplen con las validaciones correspondientes.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<bool> RegisterPlayersAsync(List<Players> players)
        {
            if (players == null || players.Count == 0)
                throw new ArgumentException("The player list cannot be empty.");

            
            if ((players.Count & (players.Count - 1)) != 0)
                throw new InvalidOperationException("The number of players must be a power of 2.");

            
            if (players.Select(p => p.Gender).Distinct().Count() > 1)
                throw new InvalidOperationException("All players must have the same gender.");

            
            if (players.GroupBy(p => p.Id).Any(g => g.Count() > 1))
                throw new InvalidOperationException("Duplicate players are not allowed.");

            await _playerRepository.AddRangeAsync(players);
            return true;
        }

        /// <summary>
        /// Método que recorre toda la lista de jugadores ingresados e invoca
        /// al método SimulateMatch para obtener los jugadores que avanzan de
        /// ronda hasta obtener el campeón o campeona.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Players SimulateTournament(List<Players> players)
        {
            if ((players.Count & (players.Count - 1)) != 0)
                throw new InvalidOperationException("The number of players must be a power of 2.");

            
            while (players.Count > 1)
            {
                var nextRound = new List<Players>();

                for (int i = 0; i < players.Count; i += 2)
                {
                    var player1 = players[i];
                    var player2 = players[i + 1];

                    
                    var winner = SimulateMatch(player1, player2);
                    nextRound.Add(winner);
                }

                players = nextRound;
            }

            return players.First(); 
        }

        public Task UpdateAsync(Players player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Criterio adoptado para elegir el ganador o ganadora de
        /// cada ronda. 
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        private Players SimulateMatch(Players player1, Players player2)
        {
            
            var random = new Random();
            int totalSkill = player1.Ability + player2.Ability;
            int chance = random.Next(0, totalSkill);

            return chance < player1.Ability ? player1 : player2;
        }
    }
}
