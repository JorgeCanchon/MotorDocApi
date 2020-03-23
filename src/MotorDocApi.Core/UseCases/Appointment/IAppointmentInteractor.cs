using System;
using System.Linq;
using System.Text;
using MotorDocApi.Core.Entities;

namespace MotorDocApi.Core.UseCases.Appointment
{
    public interface IAppointmentInteractor
    {
        IQueryable<Entities.Appointment> GetAppointment();
    }
}
