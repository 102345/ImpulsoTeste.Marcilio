using Abp.MultiTenancy;
using ImpulsoTeste.Marcilio.Authorization.Users;

namespace ImpulsoTeste.Marcilio.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
