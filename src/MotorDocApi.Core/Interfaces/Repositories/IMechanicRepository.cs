using MotorDocApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IMechanicRepository : IRepositoryBase<Mechanics>
    {
        IQueryable<Mechanics> GetTreatingMechanic(long workshopId, long vehicleId);
    }
}
