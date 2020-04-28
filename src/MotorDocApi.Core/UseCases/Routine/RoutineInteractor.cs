using Microsoft.EntityFrameworkCore;
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
            _repositoryWrapper.Routine.FindAll().Where(x => x.Status == true);

        public IQueryable<Models.Routine> GetRoutinesByWorkshop(long WorkshopId) =>
            _repositoryWrapper.Routine.FindByCondition(x => x.WorkshopsId == WorkshopId && x.Status == true);

        public long InsertRoutine(Models.Routine routine)
        {
            long result = -1;
            try
            {
                _repositoryWrapper.Routine.Create(routine);
                _repositoryWrapper.Save();
                result = routine.Idroutine;
            }
            catch(Exception)
            {

            }
            return result;
        }

        public EntityState UpdateRoutine(Models.Routine routine)
        {
            EntityState result = new EntityState();
            try
            {
                var entity = _repositoryWrapper.Routine.FindByCondition(x => x.Idroutine == routine.Idroutine).FirstOrDefault();
                entity.Name = routine.Name;
                entity.Cost = routine.Cost;
                result = _repositoryWrapper.Routine.Update(entity, "Idroutine");
                _repositoryWrapper.Save();
            }
            catch(Exception)
            {
                return EntityState.Unchanged;
            }
            return result;
        }
        public EntityState DeleteRoutine(long idRoutine)
        {
            EntityState result = new EntityState();
            try
            {
                var entity = _repositoryWrapper.Routine.FindByCondition(x => x.Idroutine == idRoutine).FirstOrDefault();
                entity.Status = false;
                result = _repositoryWrapper.Routine.Update(entity, "Idroutine");
                _repositoryWrapper.Save();
            }
            catch (Exception)
            {
                return EntityState.Unchanged;
            }
            return result;
        }
    }
}
