using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Core.UseCases.ReferenceBrand
{
    public class ReferenceBrandInteractor : IReferenceBrandInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReferenceBrandInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public EntityState DeleteReferenceBrand(long idReferenceBrand)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Models.ReferenceBrand> GetReferenceBrand() =>
        (
           _repositoryWrapper.ReferenceBrand.FindAll()
        );

        public IQueryable<Models.ReferenceBrand> GetReferenceBrandByBrand(int idBrand) =>
        (
            _repositoryWrapper.ReferenceBrand.FindByCondition(x => x.IdBrand == idBrand)
        );

        public long InsertReferenceBrand(Models.ReferenceBrand referenceBrand)
        {
            throw new NotImplementedException();
        }

        public EntityState UpdateReferenceBrand(Models.ReferenceBrand referenceBrand)
        {
            throw new NotImplementedException();
        }
    }
}
