using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}
