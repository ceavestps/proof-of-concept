using Catalog.Domain.Things;

namespace Catalog.Domain.Tests;

[TestFixture]
public class ThingNameTests
{
    [Test]
    public void Given_ValidString_When_Create_Then_IsSuccess()
    {
        const string name = "Valid Name";

        var result = ThingName.Create(name);

        result.IsSuccess.Should().BeTrue();
        result.Value!.Value.Should().Be(name);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void Given_NullOrWhitespaceString_When_Create_Then_IsFailure(string name)
    {
        var result = ThingName.Create(name);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().Contain("Name cannot be empty or whitespace.");
    }

    [TestCase("a")]
    [TestCase("ab")]
    public void Given_TooShortName_When_Create_Then_IsFailure(string name)
    {
        var result = ThingName.Create(name);

        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().Contain("Name must have at least 3 characters.");
    }
}
