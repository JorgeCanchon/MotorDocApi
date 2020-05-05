﻿using System;
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

        private RepositoryContextPostgresql _repositoryContextPostgresql;

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

        public IBrandRepository BrandRepository
        {
            get
            {
                if (brand == null)
                    brand = new BrandRepository(_repositoryContextPostgresql);
                return brand;
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
