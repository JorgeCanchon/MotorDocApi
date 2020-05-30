
namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAppointmentRepository Appointment { get; }
        IRoutineRepository Routine { get; }
        IReferenceBrandRepository ReferenceBrand { get; }
        IBrandRepository Brands { get; }
        IMechanicRepository Mechanics {get;}
        IMaintenanceRatingRepository MaintenanceRating { get; }
        IMaintenanceRoutineRepository MaintenanceRoutine { get; }
        void Commit();
        void RollBack();
        void Save();
    }
}
