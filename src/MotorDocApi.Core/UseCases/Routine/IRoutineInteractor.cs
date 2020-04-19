using System;
using System.Collections.Generic;
using System.Text;
using MotorDocApi.Core.Models;
using System.Linq;

namespace MotorDocApi.Core.UseCases.Routine
{
    public interface IRoutineInteractor
    {
        IQueryable<Models.Routine> GetRoutine();
        Models.Routine InsertRoutine(Models.Routine routine);
    }
}
