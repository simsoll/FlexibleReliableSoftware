using System;

namespace PayStation
{
    public class IllegalCoinException : Exception
    {
        public IllegalCoinException(String e) : base(e)
        {

        }
    }
}