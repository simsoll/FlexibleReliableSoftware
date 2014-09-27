using System;

namespace Proxy
{
    /** The real subject: a jpg image */
    class JpgImage : IImage
    {
        private string _filename;

        public void Load(string filename)
        {
            Console.WriteLine("*** JPGImage reading from file:" + filename + " ***");
            _filename = filename;
        }

        public string Show()
        {
            return "Showing JPG image from file " + _filename;
        }
    }
}