using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ImpulsoTeste.Marcilio.Configuration;
using ImpulsoTeste.Marcilio.EntityFrameworkCore;
using ImpulsoTeste.Marcilio.Migrator.DependencyInjection;

namespace ImpulsoTeste.Marcilio.Migrator
{
    [DependsOn(typeof(MarcilioEntityFrameworkModule))]
    public class MarcilioMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MarcilioMigratorModule(MarcilioEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MarcilioMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MarcilioConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MarcilioMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
