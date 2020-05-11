using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Core.UseCases.Mechanic
{
    public interface IMechanicInteractor
    {
        IQueryable<Models.Mechanics> GetTreatingMechanic(long workshopId, long vehicleId);
    }
}
