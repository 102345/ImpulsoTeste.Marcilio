using System.Threading.Tasks;
using Abp.Application.Services;
using ImpulsoTeste.Marcilio.Authorization.Accounts.Dto;

namespace ImpulsoTeste.Marcilio.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
