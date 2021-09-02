using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ImpulsoTeste.Marcilio.Authorization;
using ImpulsoTeste.Marcilio.Authorization.Roles;
using ImpulsoTeste.Marcilio.Authorization.Users;
using ImpulsoTeste.Marcilio.Editions;
using ImpulsoTeste.Marcilio.MultiTenancy;

namespace ImpulsoTeste.Marcilio.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
