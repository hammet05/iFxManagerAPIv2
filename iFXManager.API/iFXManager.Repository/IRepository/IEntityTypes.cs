using iFXManager.DAL.Models;

namespace iFXManager.Repository.IRepository
{
    public interface IEntityTypes
    {
        Task<IEnumerable<EntityType>> GetAllEntityTypesAsync(CancellationToken cancellationToken = default);
    }
}
