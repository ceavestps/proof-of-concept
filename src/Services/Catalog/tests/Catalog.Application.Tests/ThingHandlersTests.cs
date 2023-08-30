using Catalog.Application.Things.CreateThing;
using Catalog.Domain.Things;

namespace Catalog.Application.Tests;

[TestFixture]
public class ThingHandlersTests
{
    private IThingRepository _thingRepositoryMock = null!;

    [SetUp]
    public void Setup()
    {
        _thingRepositoryMock = Substitute.For<IThingRepository>();
    }

    [Test]
    public async Task CreateThingCommandHandler_ShouldReturnSuccessResult()
    {
        var command = new CreateThingCommand("Valid Name");
        var handler = new CreateThingCommandHandler(_thingRepositoryMock);

        var result = await handler.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        _thingRepositoryMock.Received ().Create (Arg.Is<Thing> (t => t.Name.Value == command.Name));
        await _thingRepositoryMock.Received ().SaveChanges ();
    }

    [Test]
    public async Task CreateThingCommandHandler_ShouldReturnFailureResult_WhenNameIsInvalid()
    {
        var command = new CreateThingCommand(string.Empty);
        var handler = new CreateThingCommandHandler(_thingRepositoryMock);

        var result = await handler.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
        _thingRepositoryMock.DidNotReceive ().Create (Arg.Any<Thing> ());
        await _thingRepositoryMock.DidNotReceive ().SaveChanges ();
    }
}
