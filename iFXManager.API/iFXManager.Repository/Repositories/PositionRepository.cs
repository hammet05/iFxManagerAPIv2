using iFXManager.DAL;
using iFXManager.DAL.Models;
using iFXManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace iFXManager.Repository.Repositories
{
    public class PositionRepository : IPositions
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PositionRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Positions.OrderBy(p=>p.Description).Where(p=>p.Status==true).ToListAsync(cancellationToken);
        }

       
    }
}
