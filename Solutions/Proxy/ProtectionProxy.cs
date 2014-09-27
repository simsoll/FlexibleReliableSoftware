using System;

namespace Proxy
{
    class ProtectionProxy : IImage
    {
        private bool _hasAccess;
        private const string Password = "123";
        private readonly IImage _realSubject;

        public ProtectionProxy(IImage realSubject)
        {
            _realSubject = realSubject;
            _hasAccess = false;
        }


        public void Load(string filename)
        {
            _realSubject.Load(filename);
        }

        public string Show()
        {
            if (!_hasAccess)
            {
                if (Console.ReadLine() != Password)
                {
                    return "Access denied!";
                }
                _hasAccess = true;

            }

            return _realSubject.Show();
        }
    }
}