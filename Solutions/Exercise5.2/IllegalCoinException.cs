using System;

namespace Exercise5._2
{
    public class IllegalCoinException : Exception
    {
        public IllegalCoinException(String e) : base(e)
        {

        }
    }
}