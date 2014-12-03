using System;
using System.Web;

namespace xStudio.Common.Localization
{
    public class TranslatedString : IHtmlString
    {
        private readonly string _localized;

        public TranslatedString(string text, params object[] args)
        {
            if (args != null && args.Length > 0)
                _localized = string.Format(text, args);
            else
                _localized = text;
        }

        public override string ToString()
        {
            return _localized;
        }
        public string ToHtmlString()
        {
            return _localized;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            if (_localized != null)
                hashCode ^= _localized.GetHashCode();
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var that = (TranslatedString) obj;
            return string.Equals(_localized, that._localized);
        }

        public static implicit operator string(TranslatedString text)
        {
            return text == null ? null : text.ToString();
        }
    }
}