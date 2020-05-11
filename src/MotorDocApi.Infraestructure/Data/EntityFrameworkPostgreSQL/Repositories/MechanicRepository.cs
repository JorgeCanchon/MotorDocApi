using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class MechanicRepository: RepositoryBase<Mechanics>, IMechanicRepository
    {
        public MechanicRepository(RepositoryContextPostgresql repositoryContextPostgresql)
            : base(repositoryContextPostgresql)
        {

        }
    }
}
