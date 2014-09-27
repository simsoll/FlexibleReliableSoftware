using System.Collections.Generic;
using System.Linq;

namespace Builder
{
    public class WordCountBuilder : IBuilder
    {
        private int _wordCount;

        public WordCountBuilder()
        {
            _wordCount = 0;
        }

        public void BuildSection(string text)
        {
            _wordCount += WordCount(text);
        }

        public void BuildSubsection(string text)
        {
            _wordCount += WordCount(text);
        }

        public void BuildParagraph(string text)
        {
            _wordCount += WordCount(text);
        }

        public int GetWordCount()
        {
            return _wordCount;
        }

        private static int WordCount(string text)
        {
            //string.Split(new char[0]) splits at whitespaces
            return text.Split(new char[0]).Count();
        }
    }
}