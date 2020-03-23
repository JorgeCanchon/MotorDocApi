using MotorDocApi.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using MotorDocApi.Core.Entities;
using System.Linq;

namespace MotorDocApi.Core.UseCases.Appointment
{
    public class AppointmentInteractor : IAppointmentInteractor
    {
        private IRepositoryWrapper _repositoryWrapper;
        public AppointmentInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public IQueryable<Entities.Appointment> GetAppointment() =>
            _repositoryWrapper.Appointment.FindAll();

    }
}
