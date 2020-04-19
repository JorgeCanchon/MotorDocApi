using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAppointmentRepository Appointment { get; }
        IRoutineRepository Routine { get; }
        void Commit();
        void RollBack();
        void Save();
    }
}
