using iFXManager.DAL.Models;

namespace iFXManager.Repository.IRepository
{
    public interface IIdentificationTypes
    {
        Task<IEnumerable<IdentificationType>> GetAllIdentificationTypesAsync(CancellationToken cancellationToken = default);
    }
}
