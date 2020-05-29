using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using System;
using System.Linq;

namespace MotorDocApi.Core.UseCases.Mechanic
{
    public class MechanicInteractor : IMechanicInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public MechanicInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public EntityState AssociateRoutine(Routinemechanic routinemechanic)
        {
            throw new NotImplementedException();
        }

        public EntityState DisassociateRoutine(Routinemechanic routinemechanic)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Mechanics> GetTreatingMechanic(long workshopId, long vehicleId) =>
            _repositoryWrapper
                .Mechanics
                .GetTreatingMechanic(workshopId, vehicleId);

        public EntityState ManageAppointment(Maintenanceroutine maintenanceroutine, long idAppointment)
        {
            EntityState result;
            try
            {
                var maintenance = _repositoryWrapper.MaintenanceRoutine.FindByCondition(x => x.IdMaintenance == maintenanceroutine.IdMaintenance).FirstOrDefault();
                maintenance.Kilometraje = maintenanceroutine.Kilometraje;
                maintenance.Observaciones = maintenanceroutine.Observaciones;

                result = _repositoryWrapper.MaintenanceRoutine.Update(maintenance, "IdMaintenance");
                _repositoryWrapper.Save();
                if (result == EntityState.Modified)
                {
                    var entity = _repositoryWrapper.Appointment.FindByCondition(x => x.Idappointment == idAppointment).FirstOrDefault();
                    entity.Status = 1;
                    result = _repositoryWrapper.Appointment.Update(entity, "Idappointment");
                    _repositoryWrapper.Save();
                }
            }
            catch (Exception e)
            {
                return EntityState.Unchanged;
            }
            return result;
        }
    }
}
