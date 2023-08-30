namespace Catalog.Application.Things.CreateThing;

public record CreateThingCommand (string Name) : ICommand<ThingDto>;
