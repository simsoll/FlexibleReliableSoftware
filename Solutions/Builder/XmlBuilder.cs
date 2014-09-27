using System;
using System.Text;

namespace Builder
{
    public class XmlBuilder : IBuilder
    {
        private readonly StringBuilder _result;

        public XmlBuilder()
        {
            _result = new StringBuilder();
            _result.AppendLine("<document>");
        }

        public void BuildSection(string text)
        {
            _result.AppendLine("<section>");
            _result.AppendLine(text);
            _result.AppendLine("</section>");
        }

        public void BuildSubsection(string text)
        {
            _result.AppendLine("<subsection>");
            _result.AppendLine(text);
            _result.AppendLine("</subsection>");
        }

        public void BuildParagraph(string text)
        {
            _result.AppendLine("<paragraph>");
            _result.AppendLine(text);
            _result.AppendLine("</paragraph>");
        }

        public string GetResult()
        {
            _result.AppendLine("</document>");
            return _result.ToString();
        }
    }
}