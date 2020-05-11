using Autofac;
using MotorDocApi.Core.UseCases.User;
using MotorDocApi.Core.UseCases.Appointment;
using MotorDocApi.Core.UseCases.Routine;
using MotorDocApi.Core.UseCases.ReferenceBrand;
using MotorDocApi.Core.UseCases.Brand;
using MotorDocApi.Core.UseCases.Mechanic;

namespace MotorDocApi.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserInteractor>().As<IUserInteractor>().SingleInstance();
            builder.RegisterType<AppointmentInteractor>().As<IAppointmentInteractor>().SingleInstance();
            builder.RegisterType<RoutineInteractor>().As<IRoutineInteractor>().SingleInstance();
            builder.RegisterType<ReferenceBrandInteractor>().As<IReferenceBrandInteractor>().SingleInstance();
            builder.RegisterType<BrandInteractor>().As<IBrandInteractor>().SingleInstance();
            builder.RegisterType<MechanicInteractor>().As<IMechanicInteractor>().SingleInstance();
        }
    }
}
