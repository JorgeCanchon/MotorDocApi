using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContextPostgresql repositoryContext) 
            : base(repositoryContext)
        {

        }
    }
}
