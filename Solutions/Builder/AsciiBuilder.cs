using System.Text;

namespace Builder
{
    /** A concrete builder implementing a ASCII format */
    public class AsciiBuilder : IBuilder
    {
        private readonly StringBuilder _result;
        private int _sectionCounter;
        private int _subSectionCounter;

        public AsciiBuilder()
        {
            _result = new StringBuilder();
            _sectionCounter = _subSectionCounter = 0;
        }

        public void BuildSection(string text)
        {
            _sectionCounter++;
            _result.AppendLine("" + _sectionCounter + ". " + text + "");
            _result.AppendLine("=======================");
        }

        public void BuildSubsection(string text)
        {
            _subSectionCounter++;
            _result.AppendLine("" + _sectionCounter + "." + _subSectionCounter + " " + text + "");
        }

        public void BuildParagraph(string text)
        {
            _result.AppendLine(text + "");
        }

        public string GetResult()
        {
            return _result.ToString();
        }
    }
}