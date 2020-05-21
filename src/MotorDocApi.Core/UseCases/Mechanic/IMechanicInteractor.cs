using System.Linq;

namespace MotorDocApi.Core.UseCases.Mechanic
{
    public interface IMechanicInteractor
    {
        IQueryable<Models.Mechanics> GetTreatingMechanic(long workshopId, long vehicleId);

    }
}
