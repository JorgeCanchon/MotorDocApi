using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Models;

namespace MotorDocApi.Core.UseCases.Appointment
{
    public interface IAppointmentInteractor
    {
        IQueryable<Models.Appointment> GetAppointment();
        long InsertAppointment(Models.Appointment appointment);
    }
}
