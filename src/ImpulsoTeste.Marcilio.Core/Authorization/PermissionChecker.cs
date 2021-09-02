using Abp.Authorization;
using ImpulsoTeste.Marcilio.Authorization.Roles;
using ImpulsoTeste.Marcilio.Authorization.Users;

namespace ImpulsoTeste.Marcilio.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
