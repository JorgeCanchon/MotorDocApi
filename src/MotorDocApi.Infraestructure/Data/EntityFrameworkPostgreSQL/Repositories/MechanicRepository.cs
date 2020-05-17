using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class MechanicRepository: RepositoryBase<Mechanics>, IMechanicRepository
    {
        private readonly RepositoryContextPostgresql _repositoryContext;

        public MechanicRepository(RepositoryContextPostgresql repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public IQueryable<Mechanics> GetTreatingMechanic(long workshopId, long vehicleId) =>
        (
            _repositoryContext
                .Mechanics
                .FromSqlRaw($"select * from gettreatingmechanic({workshopId},{vehicleId})")
                .Include(x => x.User)
                .Select(x => new Mechanics
                {
                    Id = x.Id,
                    User = new Users { Name = x.User.Name, LastName = x.User.LastName }
                })
        // var mechanic = _repositoryWrapper
        //     .Mechanics
        //     .Query()
        //     .Set<Models.Mechanics>()
        //     .Join(_repositoryWrapper.User,
        //             m => m.User.Id,
        //             u => u,
        //             (m, u) => new { Mechanics = m, Users = u}
        //             )

        //     .Include(x => x.User)
        //     .Include(x => x.Maintenanceroutines)
        //     .ThenInclude(m => m.Maintenances)
        //     .ThenInclude(v => v.Vehicles)
        //     .Include(m => m.Maintenanceroutines)
        //     .ThenInclude(m => m.Maintenances)
        //     .ThenInclude(a => a.Appointments)
        //     .Where(z =>
        //         z.Maintenanceroutines.Any(c => c.Maintenances.Appointments.WorkshopsId == workshopId ) &&
        //         z.Maintenanceroutines.Any(c => c.Maintenances.Vehicles.Any(x => x.Id == vehicleId)) 
        //     );
        // //_repositoryWrapper
        // //.Mechanics
        // //.ExecuteQuery($"select * from gettreatingmechanic({workshopId}, {vehicleId})");
        //return mechanic
        //.Select(x => new Mechanics
        //{
        //    Id = x.Id,
        //    User = new Users { Name = x.User.Name, LastName = x.User.LastName }
        //});
        );
    }
}
