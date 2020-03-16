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
        public IUserRepository user;
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
        public void Save()
        {
            _repositoryContextPostgresql.SaveChanges();
        }
    }
}
