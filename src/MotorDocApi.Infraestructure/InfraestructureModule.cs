using Autofac;
using MotorDocApi.Core.Interfaces.Repositories;
using MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL;

namespace MotorDocApi.Infraestructure
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryWrapper>().As<IRepositoryWrapper>().InstancePerLifetimeScope();
        }
    }
}
