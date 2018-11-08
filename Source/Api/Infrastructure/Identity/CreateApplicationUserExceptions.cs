using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// Throw when an error occurs creating a new ApplicationUser.
    /// </summary>
    [Serializable]
    public class CreateApplicationUserException : Exception
    {
        /// <summary>
        /// Creates a new instance based on the supplied failedResult.
        /// Builds a formatted message based on failedResult.Errors.
        /// </summary>
        /// <param name="failedResult">The IdentityResult that has failed.</param>
        public CreateApplicationUserException(IdentityResult failedResult) : this(failedResult.Errors)
        { }

        /// <summary>
        /// Creates a new instance based on the supplied IdentityErrors.
        /// Builds a formatted message based on errors.
        /// </summary>
        /// <param name="errors">The IdentityErrors.</param>
        public CreateApplicationUserException(IEnumerable<IdentityError> errors) : this(errors.Select(error => $"Code: { error.Code }; Description: { error.Description }").Aggregate((line1, line2) => line1 + "\n" + line2))
        { }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="message">The message for the error.</param>
        public CreateApplicationUserException(string message) : base(message)
        { }
    }
}