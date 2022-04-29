using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Poke.Persistence.Models;
using Poke.Persistence.Settings;

namespace Poke.Persistence.Data;

public class FavoriteDbContext : DbContext
{   
    public virtual DbSet<FavoritePokemon> FavoritePokemons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Configuration.ConnectionString;
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FavoritePokemon>(entity =>
        {
            entity.HasKey(e => e.PokemonId);
            entity.Property(e => e.PokemonId);
            entity.Property(e => e.PokemonName);
        });
    }
}
