using System.Linq;

namespace xStudio.Common.Localization
{
    public static class LocalizerExtensions
    {
        public static TranslatedString Plural(this Localizer T, string textSingular, string textPlural, int count, params object[] args)
        {
            return T(count == 1 ? textSingular : textPlural, new object[] { count }.Concat(args).ToArray());
        }
    }
}