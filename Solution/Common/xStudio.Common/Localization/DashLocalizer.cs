namespace xStudio.Common.Localization
{
    public static class DashLocalizer
    {
        private static readonly Localizer NullInstance;

        static DashLocalizer()
        {
            NullInstance = (text, args) => new TranslatedString("[" + text + "]", args);
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