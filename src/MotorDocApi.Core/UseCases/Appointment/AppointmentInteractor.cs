using MotorDocApi.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using MotorDocApi.Core.Models;
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

        public IQueryable<Models.Appointment> GetAppointment() =>
            _repositoryWrapper.Appointment.FindAll();

        public Models.Appointment InsertAppointment(Models.Appointment appointment)
        {
            Models.Appointment result = null;
            try
            {
                result = _repositoryWrapper.Appointment.Create(appointment);
                _repositoryWrapper.Save();
            }
            catch { }
            return result;
        }
    }
}
