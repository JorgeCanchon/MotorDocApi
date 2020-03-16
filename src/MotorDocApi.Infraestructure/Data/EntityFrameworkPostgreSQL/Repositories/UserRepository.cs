using MotorDocApi.Core.Entities;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContextPostgresql repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
