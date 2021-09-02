using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ImpulsoTeste.Marcilio.Configuration;

namespace ImpulsoTeste.Marcilio.Web.Host.Startup
{
    [DependsOn(
       typeof(MarcilioWebCoreModule))]
    public class MarcilioWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MarcilioWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MarcilioWebHostModule).GetAssembly());
        }
    }
}
