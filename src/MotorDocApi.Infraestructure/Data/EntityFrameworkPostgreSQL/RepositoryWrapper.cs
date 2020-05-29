using System;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;


namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUserRepository user;

        private IAppointmentRepository appointment;

        private IRoutineRepository routine;

        private IReferenceBrandRepository referenceBrand;

        private IBrandRepository brand;

        private IMechanicRepository mechanic;

        private IMaintenanceRatingRepository maintenanceRating;

        private IMaintenanceRoutineRepository maintenanceRoutine;

        private readonly RepositoryContextPostgresql _repositoryContextPostgresql;

        public RepositoryWrapper(RepositoryContextPostgresql repositoryContextPostgresql)
        {
            _repositoryContextPostgresql = repositoryContextPostgresql ?? throw new ArgumentNullException(nameof(repositoryContextPostgresql));
        }

        public IUserRepository User
        {
            get {
                if (user == null)
                    user = new UserRepository(_repositoryContextPostgresql);
                return user;
            }
        }

        public IAppointmentRepository Appointment 
        {
            get
            {
                if (appointment == null)
                    appointment = new AppointmentRepository(_repositoryContextPostgresql);
                return appointment;
            }
        }

        public IRoutineRepository Routine 
        {
            get 
            {
                if (routine == null)
                    routine = new RoutineRepository(_repositoryContextPostgresql);
                return routine;
            }
        }

        public IReferenceBrandRepository ReferenceBrand
        {
            get
            {
                if (referenceBrand == null)
                    referenceBrand = new ReferenceBrandRepository(_repositoryContextPostgresql);
                return referenceBrand;
            }
        }

        public IBrandRepository Brands
        {
            get
            {
                if (brand == null)
                    brand = new BrandRepository(_repositoryContextPostgresql);
                return brand;
            }
        }

        public IMechanicRepository Mechanics
        {
            get
            {
                if (mechanic == null)
                    mechanic = new MechanicRepository(_repositoryContextPostgresql);
                return mechanic;
            }
        }

        public IMaintenanceRatingRepository MaintenanceRating
        {
            get
            {
                if (maintenanceRating == null)
                    maintenanceRating = new MaintenaceRatingRepository(_repositoryContextPostgresql);
                return maintenanceRating;
            }
        }

        public IMaintenanceRoutineRepository MaintenanceRoutine
        {
            get
            {
                if (maintenanceRoutine == null)
                    maintenanceRoutine = new MaintenanceRoutineRepository(_repositoryContextPostgresql);
                return maintenanceRoutine;
            }
        }

        public void Commit()
        {

        }
        public void RollBack()
        {

        }
        public void Save()
        {
            _repositoryContextPostgresql.SaveChanges();
        }
    }
}
