using System;
using System.Drawing;

namespace Proxy
{
    /** This class plays the client role for the subject */
    class WordProcessor
    {
        private string _textPage1;
        private string _textPage2;
        private IImage _imagePage2;

        public void Load(string filename)
        {
            // I ignore the file name :)
            _textPage1 = "This is the text of page 1, that has no images.";
            _textPage2 = "This is another text, on page 2, with a single image.";
            _imagePage2 = new AccessCounterProxy(new ProtectionProxy(new ProxyImage()));
            _imagePage2.Load("flower.jpg");
        }

        public void ShowPage(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine( _textPage1 );
                    break;
                case 2:
                    Console.WriteLine( _textPage2 );
                    Console.WriteLine( _imagePage2.Show() );
                    break;
            }
        }
    }
}