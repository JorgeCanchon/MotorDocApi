using Autofac;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Core.UseCases.User;
using MotorDocApi.Core.UseCases.Appointment;
using System;
using System.Collections.Generic;
using System.Text;
using MotorDocApi.Core.UseCases.Routine;

namespace MotorDocApi.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserInteractor>().As<IUserInteractor>().SingleInstance();
            builder.RegisterType<AppointmentInteractor>().As<IAppointmentInteractor>().SingleInstance(); 
            builder.RegisterType<RoutineInteractor>().As<IRoutineInteractor>().SingleInstance();
        }
    }
}
