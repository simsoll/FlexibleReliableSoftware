using System;

namespace Builder
{
    /** This class plays the director role of the builder pattern */
    public class WordProcessor
    {
        /** The document
            1. The Builder Pattern
            ===================
              1.1 Intent
                Separate the construction of a complex object 
                from its representation so that the same construction 
                process can create different representations.
              1.2 Problem
                (The problem goes here)

            is coded as named strings to avoid defining a large
            datastructure.
          */
        private const String Section = "The Builder Pattern";
        private const String SubSection1 = "Intent";

        private const String Paragraph1 =
            "Separate the construction of a complex object\n" +
            "from its representation so that the same construction\n" + "process can create different representations.";

        private const String SubSection2 = "Problem";
        private const String Paragraph2 = "(The problem goes here)";

        public void Construct(IBuilder builder)
        {
            /* a real constructor would iterate over a
             * data structure, here I have hardcoded the
             * document to keep the code small */
            builder.BuildSection(Section);
            builder.BuildSubsection(SubSection1);
            builder.BuildParagraph(Paragraph1);
            builder.BuildSubsection(SubSection2);
            builder.BuildParagraph(Paragraph2);
        }
    }
}