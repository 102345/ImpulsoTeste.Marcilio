using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ImpulsoTeste.Marcilio.Authorization;

namespace ImpulsoTeste.Marcilio
{
    [DependsOn(
        typeof(MarcilioCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MarcilioApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MarcilioAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MarcilioApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
