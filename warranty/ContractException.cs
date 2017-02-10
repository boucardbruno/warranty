using System;

namespace warranty
{
    public class ContractException : Exception
    {
        public ContractException(string message): base(message)
        {
        }
    }
}