using System;
using System.Text;

namespace Builder
{
    /** A concrete builder implementing a HTML format */
    public class HtmlBuilder : IBuilder
    {
        private readonly StringBuilder _result;

        public HtmlBuilder()
        {
            _result = new StringBuilder();
        }

        public void BuildSection(String text)
        {
            _result.AppendLine("<H1>" + text + "</H1>");
        }

        public void BuildSubsection(String text)
        {
            _result.AppendLine("<H2>" + text + "</H2>");
        }

        public void BuildParagraph(String text)
        {
            _result.AppendLine("<P>\n" + text + "\n</P>");
        }

        public string GetResult()
        {
            return _result.ToString();
        }
    }
}