using iFXManager.API.Models;
using iFXManager.DAL.DTOs;
using iFXManager.DAL.Models;

namespace iFXManager.Repository.IRepository
{
    public interface IEntities
    {
        Task<IEnumerable<Entity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<Entity>> GetEntityByIdAsync(int id,CancellationToken cancellationToken = default);
        Task<bool> ExistEntity(Entity entity, CancellationToken cancellationToken = default);

        Task<bool> SaveEntityAsync(Entity entity, CancellationToken cancellationToken = default);

        bool ConfirmChanges();

    }
}
