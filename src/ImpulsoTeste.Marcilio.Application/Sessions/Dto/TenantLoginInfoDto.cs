using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ImpulsoTeste.Marcilio.MultiTenancy;

namespace ImpulsoTeste.Marcilio.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
