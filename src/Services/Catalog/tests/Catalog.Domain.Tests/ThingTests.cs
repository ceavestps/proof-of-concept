namespace Catalog.Domain.Tests;

[TestFixture]
public class ThingTests
{
    [Test]
    public void Constructor_ValidGuidAndValidName_ShouldSetProperties ()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Valid Name";

        // Act
        var thing = new Thing(id, name);

        // Assert
        thing.Id.Should().Be(id);
        thing.Name.Should().Be(name);
    }

    [Test]
    public void Constructor_EmptyGuidAndValidName_ShouldThrowException ()
    {
        // Arrange
        var id = Guid.Empty;
        var name = "Valid Name";

        // Act
        var action = () => { var _ = new Thing(id, name); };

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("ab")]
    public void Constructor_ValidGuidAndInvalidName_ShouldThrowException (string name)
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var action = () => { var _ = new Thing(id, name); };

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}
