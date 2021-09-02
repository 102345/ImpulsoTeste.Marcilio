using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ImpulsoTeste.Marcilio.Configuration.Dto;

namespace ImpulsoTeste.Marcilio.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MarcilioAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
