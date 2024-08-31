using iFXManager.DAL.Models;

namespace iFXManager.Repository.IRepository
{
    public interface IPositions
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync(CancellationToken cancellationToken = default);
    }
}
