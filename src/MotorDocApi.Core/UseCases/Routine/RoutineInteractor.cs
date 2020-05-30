using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;
using System;
using System.Linq;

namespace MotorDocApi.Core.UseCases.Routine
{
    public class RoutineInteractor : IRoutineInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public RoutineInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public IQueryable<Models.Routine> GetRoutine() =>
            _repositoryWrapper.Routine.FindAll().Where(x => x.Status);

        public IQueryable<Models.Routine> GetRoutinesByWorkshopReference(long workshopId, long idReferenceBrand) =>
            _repositoryWrapper.Routine.GetRoutinesByWorkshopReference(workshopId, idReferenceBrand);

        public long InsertRoutine(Models.Routine routine)
        {
            long result;
            try
            {
                _repositoryWrapper.Routine.Create(routine);
                _repositoryWrapper.Save();
                result = routine.IdRoutine;
            }
            catch(Exception)
            {
                result = -1;
            }
            return result;
        }

        public EntityState UpdateRoutine(Models.Routine routine)
        {
            EntityState result;
            try
            {
                var entity = _repositoryWrapper
                .Routine
                .GetRoutineById(routine.IdRoutine);

                entity.Name = routine.Name;

                var routinereference = entity.RoutineBrand.FirstOrDefault();
                routinereference.IdReferenceBrand = routine.RoutineBrand.First().IdReferenceBrand; 
                routinereference.Cost = routine.RoutineBrand.First().Cost;
                routinereference.EstimatedTime = routine.RoutineBrand.First().EstimatedTime;
                result = _repositoryWrapper.Routine.Update(entity, "IdRoutine");
                _repositoryWrapper.Save();
            }
            catch(Exception e)
            {
                return EntityState.Unchanged;
            }
            return result;
        }

        public EntityState DeleteRoutine(long idRoutine)
        {
            EntityState result;
            try
            {
                var entity = _repositoryWrapper.Routine.FindByCondition(x => x.IdRoutine == idRoutine).FirstOrDefault();
                entity.Status = false;
                result = _repositoryWrapper.Routine.Update(entity, "IdRoutine");
                _repositoryWrapper.Save();
            }
            catch (Exception e)
            {
                return EntityState.Unchanged;
            }
            return result;
        }

        public IQueryable<Models.Routine> GetRoutinesByWorkshop(long workshopId) =>
         _repositoryWrapper.Routine.GetRoutinesByWorkshop(workshopId);
    }
}
