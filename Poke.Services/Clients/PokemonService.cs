using Poke.Services.Schemas;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Poke.Services.Clients;

public class PokemonService : IPokemonService
{
    private readonly IConfiguration Configuration;
    private readonly HttpClient _httpCliente;

    private readonly Uri _baseUri;

    public PokemonService(HttpClient httpClient, IConfiguration configuration)
    {
        Configuration = configuration;
        _httpCliente = httpClient;
        _baseUri = new Uri(Configuration["PokeApiBaseUrl"]);
    }

    public async Task<PokemonSingleResponse> GetPokemonAsync(string pokemon)
    {
        var uri = new Uri(_baseUri, pokemon);
        var resp = await _httpCliente.GetStringAsync(uri);
        var result = JsonConvert.DeserializeObject<PokemonSingleResponse>(resp);
        return result;
    }

    public async Task<PokemonListResponse> GetPokemonListAsync(int page, int items)
    {
        var uri = GetListUri(page, items);
        var resp = await _httpCliente.GetStringAsync(uri);
        var result = JsonConvert.DeserializeObject<PokemonListResponse>(resp);
        return result;
    }

    public Uri GetListUri(int page, int items)
    {
        int offset = page * items - items;
        int limit = items;
        string queryParams = $"?offset={offset}&limit={limit}";
        var uri = new Uri(_baseUri, queryParams);
        return uri;
    }
}
