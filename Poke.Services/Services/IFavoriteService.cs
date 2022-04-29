using Poke.Persistence.Models;

namespace Poke.Services.Services;

public interface IFavoriteService
{
    FavoritePokemon GetFavoriteById(int id);
    
    List<FavoritePokemon> GetAllFavorites();

    void AddFavorite(FavoritePokemon pokemon);

    bool DeleteFavoriteById(int id);
}
