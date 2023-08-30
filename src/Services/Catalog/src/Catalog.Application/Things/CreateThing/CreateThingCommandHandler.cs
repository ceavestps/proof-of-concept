using Catalog.Domain;
using Catalog.Domain.Things;

namespace Catalog.Application.Things.CreateThing;

public class CreateThingCommandHandler : ICommandHandler<CreateThingCommand, ThingDto>
{
    private readonly IThingRepository _thingRepository;

    public CreateThingCommandHandler (IThingRepository thingRepository)
    {
        _thingRepository = thingRepository;
    }

    public async Task<Result<ThingDto>> Handle (CreateThingCommand command, CancellationToken cancellationToken)
    {
        var id   = Guid.NewGuid ();
        var name = ThingName.Create (command.Name);
        if (name.IsFailure)
            return Result.Failure<ThingDto> ($"{command.Name} is not a valid Thing name.", command.Name);

        var thing = new Thing (id, name.Value);

        _thingRepository.Create(thing);
        await _thingRepository.SaveChanges ();

        return Result.Success (new ThingDto (thing.Id, thing.Name.Value));
    }
}
