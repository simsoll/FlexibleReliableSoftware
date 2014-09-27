namespace Builder
{
    /** A concrete builder that simply counts parts */
    public class CountBuilder : IBuilder
    {
        private int _section;
        private int _subsection; 
        private int _paragraph;

        public CountBuilder()
        {
            _section = 0;
            _subsection = 0;
            _paragraph = 0;
        }

        public void BuildSection(string text)
        {
            _section++;
        }

        public void BuildSubsection(string text)
        {
            _subsection++;
        }

        public void BuildParagraph(string text)
        {
            _paragraph++;
        }

        public int GetSectionCount()
        {
            return _section;
        }

        public int GetSubSectionCount()
        {
            return _subsection;
        }

        public int GetParagraphCount()
        {
            return _paragraph;
        }
    }
}