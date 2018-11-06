using System;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Infrastructure.Services
{
    [Serializable]
    internal class RegisterUserException : Exception
    {
        public RegisterUserException(IdentityResult createUserResult) : this(createUserResult.Errors.Select(error => $"Code: {error.Code}; Description: {error.Description}").Aggregate((error1, error2) => error1 + "\n" + error2))
        { }

        public RegisterUserException(string message) : base(message)
        { }

        public RegisterUserException(string message, Exception innerException) : base(message, innerException)
        { }

        protected RegisterUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}