using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ImpulsoTeste.Marcilio.Controllers
{
    public abstract class MarcilioControllerBase: AbpController
    {
        protected MarcilioControllerBase()
        {
            LocalizationSourceName = MarcilioConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
