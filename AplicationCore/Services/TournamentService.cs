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

        /// <summary>
        /// Método que recibe dos colecciones de MalePlayers y FemalePlayers respectivamente.
        /// Luego de validar si los registros son potencias de 2, realiza la simulación del 
        /// torneo de cada género guardandolo en memoria. Por último, envia las colecciones
        /// de jugadores/as para percistir en la base de datos y posterior retorno al controlador.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<(MalePlayers? maleChampion, FemalePlayers? femaleChampion)> SimulateTournament(
            IEnumerable<MalePlayers> malePlayers,
            IEnumerable<FemalePlayers> femalePlayers)
        {
            // Validar que las listas sean potencias de 2
            if (!IsPowerOfTwo(malePlayers.Count()) || !IsPowerOfTwo(femalePlayers.Count()))
            {
                throw new InvalidOperationException("El número de jugadores en cada género debe ser una potencia de 2.");
            }

            var maleChampion = SimulateSingleTournament(malePlayers.ToList(), DetermineMaleWinner);
            var femaleChampion = SimulateSingleTournament(femalePlayers.ToList(), DetermineFemaleWinner);

            await _playerRepository.AddRangeAsync(malePlayers,femalePlayers);

            return (maleChampion, femaleChampion);
        }

        private TPlayer SimulateSingleTournament<TPlayer>(
        List<TPlayer> players,
        Func<TPlayer, TPlayer, TPlayer> determineWinner)
        {
            while (players.Count > 1)
            {
                players = SimulateRound(players, determineWinner);
            }
            return players.First();
        }

        private List<TPlayer> SimulateRound<TPlayer>(
            List<TPlayer> players,
            Func<TPlayer, TPlayer, TPlayer> determineWinner)
        {
            var nextRound = new List<TPlayer>();
            for (int i = 0; i < players.Count; i += 2)
            {
                var winner = determineWinner(players[i], players[i + 1]);
                nextRound.Add(winner);
            }
            return nextRound;
        }

        private MalePlayers DetermineMaleWinner(MalePlayers player1, MalePlayers player2)
        {
            return player1.Strength + player1.Ability >= player2.Strength + player2.Ability ? player1 : player2;
        }

        private FemalePlayers DetermineFemaleWinner(FemalePlayers player1, FemalePlayers player2)
        {
            return player1.Ability+ player1.ReactionTime >= player2.Ability + player2.ReactionTime ? player1 : player2;
        }

        private bool IsPowerOfTwo(int n)
        {
            return (n & (n - 1)) == 0 && n > 0;
        }
               
        public Task UpdateAsync(Players player)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Players> GetAllPlayers()
        {
            List<Players> lsPlayer = new List<Players>();
            var listPlayer =  _playerRepository.GetAllPlayers();
            return listPlayer;
        }

        public async Task GetPlayersAsync()
        {
            List<Players> lsPlayer = new List<Players>();
            var listPlayer = await _playerRepository.GetAllAsync();
        }
    }
}
