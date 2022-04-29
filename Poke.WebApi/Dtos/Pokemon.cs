namespace Poke.WebApi.Dtos;

public class Pokemon {
    public int Id { get; set; }

    public string Name { get; set; }

    public List<string> Types { get; set; }

    public int BaseExperience { get; set; }

    public int Height { get; set; }

    public int Weight { get; set; }
    
    public List<Stat> Stats { get; set; }

    public string SpriteUrl { get; set; }
}
