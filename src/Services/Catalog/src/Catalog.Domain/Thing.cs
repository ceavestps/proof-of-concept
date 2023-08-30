namespace Catalog.Domain;

public class Thing
{
    public Guid   Id   { get; set; }
    public string Name { get; set; }

    public Thing (Guid id, string name)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id should not be empty.", nameof(id));

        Id = id;

        if (string.IsNullOrWhiteSpace (name) || name.Length < 3)
            throw new ArgumentException("Name should be at least 3 characters long.", nameof(name));

        Name = name;
    }
}
