using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ImpulsoTeste.Marcilio.EntityFrameworkCore;
using ImpulsoTeste.Marcilio.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ImpulsoTeste.Marcilio.Web.Tests
{
    [DependsOn(
        typeof(MarcilioWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MarcilioWebTestModule : AbpModule
    {
        public MarcilioWebTestModule(MarcilioEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MarcilioWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MarcilioWebMvcModule).Assembly);
        }
    }
}