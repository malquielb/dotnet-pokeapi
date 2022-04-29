using Poke.WebApi.Dtos;
using Poke.Services.Schemas;

namespace Poke.WebApi.Mappers;

public static class PokemonMapper
{
    public static Pokemon Map(PokemonSingleResponse pokemonResponse)
    {
        var Pokemon = new Pokemon()
        {
            Id = pokemonResponse.id,
            Name = pokemonResponse.name,
            BaseExperience = pokemonResponse.base_experience,
            Types = pokemonResponse.types.Select(t => t.type.name).ToList(),
            Height = pokemonResponse.height,
            Weight = pokemonResponse.weight,
            Stats = pokemonResponse.stats.Select(s =>
                {
                    return new Dtos.Stat(s.stat.name, s.base_stat);
                }).ToList(),
            SpriteUrl = pokemonResponse.sprites.front_default
        };
        return Pokemon;
    }
}
