namespace Poke.WebApi.Dtos;

public struct Stat {
    public Stat(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; }

    public int Value { get; }
}
