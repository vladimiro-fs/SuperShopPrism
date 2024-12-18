using System.Globalization;
using System.Threading;
using SuperShopPrism.Helpers;
using SuperShopPrism.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SuperShopPrism.Droid.Implementations.Localize))]
namespace SuperShopPrism.Droid.Implementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = "en";

            Java.Util.Locale androidLocale = Java.Util.Locale.Default;
            netLanguage = AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));

            CultureInfo ci = null;

            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException)
            {
                try
                {
                    string fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException)
                {
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private string AndroidToDotnetLanguage(string androidLanguage)
        {
            string netLanguage = androidLanguage;

            switch (androidLanguage)
            {
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
                    break;

                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }

            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            string netLanguage = platCulture.LanguageCode;

            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT";
                    break;
                case "gsw":
                    netLanguage = "de-CH";
                    break;
            }

            return netLanguage;
        }
    }
}