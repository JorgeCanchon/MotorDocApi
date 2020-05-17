using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MotorDocApi.Core.Models;

namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IRoutineRepository : IRepositoryBase<Routine>
    {
        IQueryable<Routine> GetRoutinesByWorkshopReference(long workshopId, long idReferenceBrand);
        IQueryable<Routine> GetRoutinesByWorkshop(long workshopId);
        Routine GetRoutineById(long idRoutine);
    }
}
