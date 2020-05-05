using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class ReferenceBrandRepository : RepositoryBase<ReferenceBrand>, IReferenceBrandRepository
    {
        public ReferenceBrandRepository(RepositoryContextPostgresql repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
