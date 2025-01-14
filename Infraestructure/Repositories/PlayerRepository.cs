using AplicationCore.Context;
using AplicationCore.Entities;
using AplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
           
        private readonly PlayersContext _playersContext;

        public PlayerRepository(PlayersContext playersContext)
        {
            _playersContext = playersContext;
        }

        public async Task AddAsync(Players player)
        {
            _playersContext.Players.AddAsync(player);
            await _playersContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Players> players)
        {
            _playersContext.Players.AddRangeAsync(players);
            await _playersContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var player = await GetByIdAsync(id);
            if (player != null)
            {
                _playersContext.Players.Remove(player);
            }
            await _playersContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _playersContext.Players.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Players>> GetAllAsync()
        {
            return await _playersContext.Players.ToListAsync();
        }

        public async Task<Players?> GetByIdAsync(int id)
        {
            return await _playersContext.Players.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _playersContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Players player)
        {
            _playersContext.Players.Update(player);
            await _playersContext.SaveChangesAsync();
        }
    }
}
