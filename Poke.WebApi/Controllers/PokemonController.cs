using Microsoft.AspNetCore.Mvc;
using Poke.Services.Clients;
using Poke.WebApi.Dtos;
using Poke.WebApi.Mappers;

namespace Poke.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    // Get a single pokemon and it's details
    [HttpGet("{pokemon}")]
    public async Task<ActionResult<Pokemon>> GetPokemon(string pokemon)
    {
        try
        {
            var pokemonData = await _pokemonService.GetPokemonAsync(pokemon);
            var result = PokemonMapper.Map(pokemonData);
            return result;
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(ex.StatusCode == null ? 500 : (int)ex.StatusCode, ex.Message);
        }
    }

    // Get a page with list of N pokemon
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonList(
        [FromQuery] int page = 1, [FromQuery] int items = 20)
    {
        try
        {
            var pokemonList = await _pokemonService.GetPokemonListAsync(page, items);
            var taskList = pokemonList.results.Select(p => _pokemonService.GetPokemonAsync(p.name));
            var pokemonDetailList = await Task.WhenAll(taskList);
            var result = pokemonDetailList.Select(p => PokemonMapper.Map(p));
            return result.ToList();
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(ex.StatusCode == null ? 500 : (int)ex.StatusCode, ex.Message);
        }
    }
}
