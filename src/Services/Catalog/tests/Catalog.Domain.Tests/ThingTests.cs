using Catalog.Domain.Things;

namespace Catalog.Domain.Tests;

[TestFixture]
public class ThingTests
{
   [Test]
   public void Given_IdAndName_When_Constructor_Then_PropertiesShouldBeSet ()
   {
      var id         = Guid.NewGuid ();
      var nameResult = ThingName.Create ("Valid Name");
      nameResult.IsSuccess.Should ().BeTrue ();

      var thing = new Thing (id, nameResult.Value);

      thing.Id.Should ().Be (id);
      thing.Name.Should ().Be (nameResult.Value);
   }

   [Test]
   public void Given_IdAndNullName_When_Constructor_Then_ArgumentExceptionShouldBeThrown ()
   {
      var id = Guid.Empty;

      var action = () => _ = new Thing (id, null);

      action.Should ().Throw<ArgumentException> ();
   }
}
