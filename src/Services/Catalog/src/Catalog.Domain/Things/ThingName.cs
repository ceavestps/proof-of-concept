namespace Catalog.Domain.Things;

public class ThingName
{
    public string Value { get; private set; }

    private ThingName (string value)
    {
        Value = value;
    }

    public static Result<ThingName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<ThingName>("Name cannot be empty or whitespace.");
        if ( value.Length < 3)
            return Result.Failure<ThingName>("Name must have at least 3 characters.");

        return Result.Success(new ThingName (value));
    }
}
