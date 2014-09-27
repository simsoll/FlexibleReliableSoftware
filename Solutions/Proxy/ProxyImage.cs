using System;

namespace Proxy
{
    /** The proxy */
    class ProxyImage : IImage
    {
        private string _filename;
        private IImage _realSubject;

        public void Load(string filename)
        {
            // just remember the filename
            _filename = filename;
            _realSubject = null;
        }

        public string Show()
        {
            if (_realSubject == null)
            {
                _realSubject = new JpgImage();
                _realSubject.Load(_filename);
            }

            return _realSubject.Show();
        }
    }
}