using System.Linq;

namespace MotorDocApi.Core.UseCases.Appointment
{
    public interface IAppointmentInteractor
    {
        IQueryable<Models.Appointment> GetAppointment();
        long InsertAppointment(Models.Appointment appointment);
        long QualifyAppointment(Models.Maintenancerating maintenancerating);
    }
}
