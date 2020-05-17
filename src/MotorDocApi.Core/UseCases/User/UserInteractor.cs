using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.UseCases.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Core.UseCases.User
{
    public class UserInteractor : IUserInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentException(nameof(repositoryWrapper));
        }
        
        public bool ValidateToken(int id)
        {
            var user = _repositoryWrapper.User.FindByCondition(u => u.Id == id);
            return true;
        }
    }
}
