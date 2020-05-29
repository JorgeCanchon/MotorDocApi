using MotorDocApi.Core.Models;
using System.Linq;

namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IMechanicRepository : IRepositoryBase<Mechanics>
    {
        IQueryable<Mechanics> GetTreatingMechanic(long workshopId, long vehicleId);
    }
}
