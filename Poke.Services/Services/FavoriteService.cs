using Poke.Persistence.Models;
using Poke.Persistence.Data;

namespace Poke.Services.Services;

public class FavoriteService : IFavoriteService
{
    private readonly FavoriteDbContext _context;

    public FavoriteService(FavoriteDbContext context)
    {
        _context = context;
    }

    public bool DeleteFavoriteById(int id)
    {
        FavoritePokemon favorite = _context.FavoritePokemons.Where(
            f => f.PokemonId.Equals(id)).FirstOrDefault();
        if (favorite == null)
        {
            return false;
        }
        _context.FavoritePokemons.Remove(favorite);
        _context.SaveChanges();
        return true;
    }

    public List<FavoritePokemon> GetAllFavorites()
    {
        return _context.FavoritePokemons.ToList();
    }

    public FavoritePokemon GetFavoriteById(int id)
    {
        return _context.FavoritePokemons.Where(f => f.PokemonId.Equals(id)).FirstOrDefault();
    }

    public void AddFavorite(FavoritePokemon pokemon)
    {
        _context.Add<FavoritePokemon>(pokemon);
        _context.SaveChanges();
    }
}
