using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MotorDocApi.Core.Models;

namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IRoutineRepository : IRepositoryBase<Routine>
    {
        IQueryable<Routine> GetRoutinesByWorkshop(long workshopId, long idReferenceBrand);
        Routine GetRoutineById(long idRoutine);
    }
}
