using System;
using System.Collections.Generic;
using System.Text;
using MotorDocApi.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MotorDocApi.Core.UseCases.Routine
{
    public interface IRoutineInteractor
    {
        IQueryable<Models.Routine> GetRoutine();
        long InsertRoutine(Models.Routine routine);
        EntityState UpdateRoutine(Models.Routine routine);
        IQueryable<Models.Routine> GetRoutinesByWorkshopReference(long workshopId, long idReferenceBrand);
        IQueryable<Models.Routine> GetRoutinesByWorkshop(long workshopId);
        EntityState DeleteRoutine(long idRoutine);
    }
}
