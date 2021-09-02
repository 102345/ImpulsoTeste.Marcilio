using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ImpulsoTeste.Marcilio.Localization
{
    public static class MarcilioLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MarcilioConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MarcilioLocalizationConfigurer).GetAssembly(),
                        "ImpulsoTeste.Marcilio.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
