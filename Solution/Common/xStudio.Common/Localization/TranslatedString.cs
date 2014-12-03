using System;
using System.Web;

namespace xStudio.Common.Localization
{
    public class TranslatedString : IHtmlString
    {
        public TranslatedString(string pattern, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public string ToHtmlString()
        {
            throw new NotImplementedException();
        }

        public static implicit operator string(TranslatedString text)
        {
            throw new NotImplementedException();
            //return text == null ? null : text.ToString();
        }
    }
}