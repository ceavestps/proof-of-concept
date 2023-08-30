namespace Catalog.Domain.Things;

public class Thing
{
    public Guid      Id   { get; private set; }
    public ThingName Name { get; private set; }

    public Thing (Guid id, ThingName? name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
