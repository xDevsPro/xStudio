namespace xStudio.Common.Localization
{
    public static class NullLocalizer
    {
        private static readonly Localizer NullInstance;

        static NullLocalizer()
        {
            NullInstance = (text, args) => new TranslatedString(text, args);
        }

        public static Localizer Instance
        {
            get
            {
                return NullInstance;
            }
        }
    }
}