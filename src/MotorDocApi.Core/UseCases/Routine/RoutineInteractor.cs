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

        public IQueryable<Models.Routine> GetRoutinesByWorkshop(long WorkshopId, long idReferenceBrand) =>
            _repositoryWrapper
                .Routine
                .Query()
                .Set<Models.Routine>()
                .Include(x => x.RoutineBrand)
                .Where(x =>
                    x.WorkshopsId == WorkshopId &&
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
                var entity = _repositoryWrapper.Routine.FindByCondition(x => x.IdRoutine == routine.IdRoutine).FirstOrDefault();
                entity.Name = routine.Name;
                //entity.Cost = routine.Cost;
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
                var entity = _repositoryWrapper.Routine.FindByCondition(x => x.IdRoutine == idRoutine).FirstOrDefault();
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
