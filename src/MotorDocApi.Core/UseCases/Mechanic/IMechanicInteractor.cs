using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MotorDocApi.Core.UseCases.Mechanic
{
    public interface IMechanicInteractor
    {
        IQueryable<Models.Mechanics> GetTreatingMechanic(long workshopId, long vehicleId);
        EntityState AssociateRoutine(Models.Routinemechanic routinemechanic);
        EntityState DisassociateRoutine(Models.Routinemechanic routinemechanic);
        EntityState ManageAppointment(Models.Maintenanceroutine maintenanceroutine, long idAppointment);
        long GetIdMechanic(long userId);    
    }
}
