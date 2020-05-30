using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class MaintenaceRatingRepository : RepositoryBase<Maintenancerating>, IMaintenanceRatingRepository
    {
        public MaintenaceRatingRepository(RepositoryContextPostgresql repositoryContext) 
            : base(repositoryContext)
        {
        }
    }
}
