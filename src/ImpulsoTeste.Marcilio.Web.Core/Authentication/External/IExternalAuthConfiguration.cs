using System.Collections.Generic;

namespace ImpulsoTeste.Marcilio.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
