using System;
using System.Linq;
using System.Text;
using MotorDocApi.Core.Models;

namespace MotorDocApi.Core.UseCases.Appointment
{
    public interface IAppointmentInteractor
    {
        IQueryable<Models.Appointment> GetAppointment();
        Models.Appointment InsertAppointment(Models.Appointment appointment);
    }
}
