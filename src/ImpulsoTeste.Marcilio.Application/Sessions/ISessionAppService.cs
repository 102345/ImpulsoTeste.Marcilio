using System.Threading.Tasks;
using Abp.Application.Services;
using ImpulsoTeste.Marcilio.Sessions.Dto;

namespace ImpulsoTeste.Marcilio.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
