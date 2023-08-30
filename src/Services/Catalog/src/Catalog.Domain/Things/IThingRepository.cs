namespace Catalog.Domain.Things;

public interface IThingRepository
{
    void Create(Thing thing);
    Task SaveChanges ();
}
