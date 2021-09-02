using Abp.Application.Services.Dto;

namespace ImpulsoTeste.Marcilio.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

