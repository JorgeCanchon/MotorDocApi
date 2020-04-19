using MotorDocApi.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Core.UseCases.Routine
{
    public class RoutineInteractor : IRoutineInteractor
    {
        private IRepositoryWrapper _repositoryWrapper;
        public RoutineInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Models.Routine> GetRoutine() =>
            _repositoryWrapper.Routine.FindAll();

        public Models.Routine InsertRoutine(Models.Routine routine)
        {
            Models.Routine result = null;
            try
            {
                result = _repositoryWrapper.Routine.Create(routine);
                _repositoryWrapper.Save();
            }
            catch(Exception e)
            {
                var a = 0;
            }
            return result;
        }
    }
}
