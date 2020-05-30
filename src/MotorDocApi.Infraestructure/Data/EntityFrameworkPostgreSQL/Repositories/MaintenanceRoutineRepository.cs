using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class MaintenanceRoutineRepository : RepositoryBase<Maintenanceroutine>, IMaintenanceRoutineRepository
    {
        public MaintenanceRoutineRepository(RepositoryContextPostgresql repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
