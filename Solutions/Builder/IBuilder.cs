namespace Builder
{
    /** This is the Builder role, the interface that
      * defines the parts that can be built */
    public interface IBuilder
    {
        void BuildSection(string text);
        void BuildSubsection(string text);
        void BuildParagraph(string text);
    }
}