using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MotorDocApi.Core.UseCases.Mechanic
{
    public class MechanicInteractor : IMechanicInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public MechanicInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public IQueryable<Mechanics> GetTreatingMechanic(long workshopId, long vehicleId)
        {
            var mechanic = _repositoryWrapper
                .Mechanics
                .Query()
                .Set<Models.Mechanics>()
                .Include(x => x.User)
                .Include(x => x.Maintenanceroutines)
                .ThenInclude(m => m.Maintenances)
                .ThenInclude(v => v.Vehicles)
                .Include(m => m.Maintenanceroutines)
                .ThenInclude(m => m.Maintenances)
                .ThenInclude(a => a.Appointments)
                .Where(z =>
                    z.Maintenanceroutines.Any(c => c.Maintenances.Appointments.WorkshopsId == workshopId ) &&
                    z.Maintenanceroutines.Any(c => c.Maintenances.Vehicles.Any(x => x.Id == vehicleId)) 
                );
            //_repositoryWrapper
            //.Mechanics
            //.ExecuteQuery($"select * from gettreatingmechanic({workshopId}, {vehicleId})");
           return mechanic
           .Select(x => new Mechanics
           {
               Id = x.Id,
               User = new Users { Name = x.User.Name, LastName = x.User.LastName }
           });
        }
    }
}
