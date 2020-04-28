using MotorDocApi.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using MotorDocApi.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public long InsertAppointment(Models.Appointment appointment)
        {
            long result = -1;
            try
            {
                _repositoryWrapper.Appointment.Create(appointment);
                _repositoryWrapper.Save();
                result = appointment.Idappointment;
            }
            catch(Exception)
            {
            
            }
            return result;
        }
    }
}
