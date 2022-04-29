using Microsoft.AspNetCore.Mvc;
using Poke.Persistence.Models;
using Poke.Services.Services;

namespace Poke.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteService _favoriteService;

    public FavoriteController(IFavoriteService pokemonService)
    {
        _favoriteService = pokemonService;
    }

    [HttpGet("{id}")]
    public ActionResult<FavoritePokemon> GetFavoriteById(int id)
    {
        try
        {
            var result =  _favoriteService.GetFavoriteById(id);
            return result;
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(ex.StatusCode == null ? 500 : (int)ex.StatusCode, ex.Message);
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<FavoritePokemon>> GetAllFavorites()
    {
        try
        {
            var result =  _favoriteService.GetAllFavorites();
            return result;
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(ex.StatusCode == null ? 500 : (int)ex.StatusCode, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteFavoriteById(int id)
    {
        try
        {
            var result =  _favoriteService.DeleteFavoriteById(id);
            return result;
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(ex.StatusCode == null ? 500 : (int)ex.StatusCode, ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<bool> AddFavorite(FavoritePokemon pokemon)
    {
        try
        {
            var favorite = _favoriteService.GetFavoriteById(pokemon.PokemonId);
            if (favorite != null)
                return true;
            _favoriteService.AddFavorite(pokemon);
            return true;
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(ex.StatusCode == null ? 500 : (int)ex.StatusCode, ex.Message);
        }
    }
}