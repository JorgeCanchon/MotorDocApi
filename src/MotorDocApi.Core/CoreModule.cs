using Autofac;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.UseCases.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserInteractor>().As<IUserInteractor>().InstancePerLifetimeScope();
        }
    }
}
