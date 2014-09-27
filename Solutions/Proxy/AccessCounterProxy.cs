using System;

namespace Proxy
{
    class AccessCounterProxy : IImage
    {
        private readonly IImage _realSubject;
        private int _accessCounter;

        public AccessCounterProxy(IImage realSubject)
        {
            _realSubject = realSubject;
            _accessCounter = 0;
        }

        public void Load(string filename)
        {
            _realSubject.Load(filename);
        }

        public string Show()
        {
            _accessCounter++;
            return _realSubject.Show();
        }
    }
}