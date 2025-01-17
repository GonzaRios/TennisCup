using AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Players>> GetAllAsync();
        List<Players> GetAllPlayers();

        Task<Players?> GetByIdAsync(int id);

        Task AddAsync(Players player);

        Task AddRangeAsync(IEnumerable<MalePlayers> malePlayers, IEnumerable<FemalePlayers> femalePlayers);

        Task UpdateAsync(Players player);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task SaveChangesAsync();
    }
}
