using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUserRepository user;

        private IAppointmentRepository appointment;

        private RepositoryContextPostgresql _repositoryContextPostgresql;

        public RepositoryWrapper(RepositoryContextPostgresql repositoryContextPostgresql)
        {
            _repositoryContextPostgresql = repositoryContextPostgresql;
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
