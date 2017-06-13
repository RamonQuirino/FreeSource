using FreeSource.Repository.Context;

namespace FreeSource.Repository
{
    public abstract class AbstractRepository
    {
        protected readonly FreeSourceModel FreeSourceModel;

        protected AbstractRepository(FreeSourceModel freeSourceModel)
        {
            FreeSourceModel = freeSourceModel;
        }
    }
}
