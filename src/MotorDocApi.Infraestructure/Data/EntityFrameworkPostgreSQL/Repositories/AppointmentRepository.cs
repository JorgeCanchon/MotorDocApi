using MotorDocApi.Core.Models;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;

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
