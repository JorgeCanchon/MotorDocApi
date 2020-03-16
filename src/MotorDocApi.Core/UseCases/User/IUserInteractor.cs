using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Core.UseCases.User
{
    public interface IUserInteractor
    {
        bool ValidateToken(int id);
    }
}
