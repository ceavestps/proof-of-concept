using Catalog.Application.Things.CreateThing;
using Catalog.Domain;
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
    }

    [Test]
    public async Task CreateThingCommandHandler_ShouldReturnFailureResult_WhenNameIsInvalid()
    {
        var command = new CreateThingCommand(string.Empty);
        var handler = new CreateThingCommandHandler(_thingRepositoryMock);

        var result = await handler.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
}
