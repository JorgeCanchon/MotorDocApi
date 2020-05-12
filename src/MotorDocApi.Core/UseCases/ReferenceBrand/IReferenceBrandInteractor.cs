using System;
using System.Collections.Generic;
using System.Text;
using MotorDocApi.Core.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MotorDocApi.Core.UseCases.ReferenceBrand
{
    public interface IReferenceBrandInteractor
    {
        IQueryable<Models.ReferenceBrand> GetReferenceBrand();
        IQueryable<Models.ReferenceBrand> GetReferenceBrandByBrand(int idBrand);
        long InsertReferenceBrand(Models.ReferenceBrand referenceBrand);
        EntityState UpdateReferenceBrand(Models.ReferenceBrand referenceBrand);
        EntityState DeleteReferenceBrand(long idReferenceBrand);
    }
}
