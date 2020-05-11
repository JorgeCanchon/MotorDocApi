using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Core.UseCases.Brand
{
    public class BrandInteractor : IBrandInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public BrandInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }
        public IQueryable<Brands> GetBrands() =>
        (
            _repositoryWrapper.Brands.FindAll()
        );
    }
}
