using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using ImpulsoTeste.Marcilio.Authorization.Users;

namespace ImpulsoTeste.Marcilio.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        public const int MaxDescriptionLength = 5000;

        public Role()
        {
        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {
        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {
        }

        [StringLength(MaxDescriptionLength)]
        public string Description {get; set;}
    }
}
