using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MotorDocApi.Core.UseCases.Brand
{
    public interface IBrandInteractor
    {
        IQueryable<Models.Brands> GetBrands();
    }
}
