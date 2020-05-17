using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MotorDocApi.Core.UseCases.Mechanic
{
    public class MechanicInteractor : IMechanicInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public MechanicInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public IQueryable<Mechanics> GetTreatingMechanic(long workshopId, long vehicleId) =>
            _repositoryWrapper
                .Mechanics
                .GetTreatingMechanic(workshopId, vehicleId);
    }
}
