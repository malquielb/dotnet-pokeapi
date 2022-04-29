using Poke.Services.Schemas;

namespace Poke.Services.Clients;

public interface IPokemonService
{
    Task<PokemonSingleResponse> GetPokemonAsync(string pokemon);

    Task<PokemonListResponse> GetPokemonListAsync(int page, int items);
}
