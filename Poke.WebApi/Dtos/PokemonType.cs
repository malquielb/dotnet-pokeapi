namespace Poke.WebApi.Dtos;

public class PokemonType2
{
    public string name { get; set; }
    public string url { get; set; }
}

public class PokemonType
{
    public int slot { get; set; }
    public PokemonType2 type { get; set; }
}
