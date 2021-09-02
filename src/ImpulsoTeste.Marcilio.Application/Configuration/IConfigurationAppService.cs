using System.Threading.Tasks;
using ImpulsoTeste.Marcilio.Configuration.Dto;

namespace ImpulsoTeste.Marcilio.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
