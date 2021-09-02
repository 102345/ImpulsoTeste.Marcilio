using Abp.Application.Services;
using ImpulsoTeste.Marcilio.MultiTenancy.Dto;

namespace ImpulsoTeste.Marcilio.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

