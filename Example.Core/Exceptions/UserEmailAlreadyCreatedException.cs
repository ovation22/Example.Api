using System;

namespace Example.Core.Exceptions
{
    public class UserEmailAlreadyCreatedException : Exception
    {
        public UserEmailAlreadyCreatedException(string message)
            : base(message)
        {
        }
    }
}