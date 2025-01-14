using AplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Context
{
    public partial class PlayersContext : DbContext
    {   
        public virtual DbSet<Players> Players { get; set; }
        public DbSet<FemalePlayers> FemalePlayers { get; set; }
        public DbSet<MalePlayers> MalePlayers { get; set; }

        public PlayersContext(DbContextOptions<PlayersContext> options) : base(options)
        {
        }

    }
}
