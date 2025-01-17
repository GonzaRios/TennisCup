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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Players>()
                .ToTable("players");


            builder.Entity<Players>(entity=>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .UseIdentityColumn();
            });

            builder.Entity<MalePlayers>()
                .ToTable("male_players");

            builder.Entity<FemalePlayers>()
                .ToTable("female_players");
        }
    }
}
