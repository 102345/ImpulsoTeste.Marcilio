using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ImpulsoTeste.Marcilio.Authorization.Roles;
using ImpulsoTeste.Marcilio.Authorization.Users;
using ImpulsoTeste.Marcilio.MultiTenancy;

namespace ImpulsoTeste.Marcilio.EntityFrameworkCore
{
    public class MarcilioDbContext : AbpZeroDbContext<Tenant, Role, User, MarcilioDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MarcilioDbContext(DbContextOptions<MarcilioDbContext> options)
            : base(options)
        {
        }
    }
}
