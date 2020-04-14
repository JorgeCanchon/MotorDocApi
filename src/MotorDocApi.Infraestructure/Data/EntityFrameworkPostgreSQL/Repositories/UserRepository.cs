using MotorDocApi.Core.Models;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(RepositoryContextPostgresql repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
