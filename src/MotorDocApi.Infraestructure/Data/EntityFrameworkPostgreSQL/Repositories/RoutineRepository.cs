using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class RoutineRepository : RepositoryBase<Routine>, IRoutineRepository
    {
        private readonly RepositoryContextPostgresql _repositoryContext;

        public RoutineRepository(RepositoryContextPostgresql repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public IQueryable<Routine> GetRoutinesByWorkshop(long workshopId, long idReferenceBrand) =>
            _repositoryContext
                .Routines
                .Include(x => x.RoutineBrand)
                .Where(x =>
                    x.WorkshopsId == workshopId &&
                    x.Status == true &&
                    x.RoutineBrand.Any(c => c.IdReferenceBrand == idReferenceBrand)
                );

        public Routine GetRoutineById(long idRoutine) =>
           _repositoryContext
                .Routines
                .Include(x => x.RoutineBrand)
                .Where(x => x.IdRoutine == idRoutine)
                .FirstOrDefault();
    }
}
