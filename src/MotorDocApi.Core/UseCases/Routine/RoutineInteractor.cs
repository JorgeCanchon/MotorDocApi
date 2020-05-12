using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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
            _repositoryWrapper.Routine.FindAll().Where(x => x.Status == true);

        public IQueryable<Models.Routine> GetRoutinesByWorkshop(long workshopId, long idReferenceBrand) =>
            _repositoryWrapper
                .Routine
                .Query()
                .Set<Models.Routine>()
                .Include(x => x.RoutineBrand)
                .Where(x =>
                    x.WorkshopsId == workshopId &&
                    x.Status == true &&
                    x.RoutineBrand.Any(c => c.IdReferenceBrand == idReferenceBrand)
                );

        public long InsertRoutine(Models.Routine routine)
        {
            long result = -1;
            try
            {
                _repositoryWrapper.Routine.Create(routine);
                _repositoryWrapper.Save();
                result = routine.IdRoutine;
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
                var entity = _repositoryWrapper
                .Routine
                .Query()
                .Set<Models.Routine>()
                .Include(x => x.RoutineBrand)
                .Where(x => x.IdRoutine == routine.IdRoutine)
                .FirstOrDefault();

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
        public EntityState DeleteRoutine(long idroutine)
        {
            EntityState result = new EntityState();
            try
            {
                var entity = _repositoryWrapper.Routine.FindByCondition(x => x.IdRoutine == idroutine).FirstOrDefault();
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
    }
}
