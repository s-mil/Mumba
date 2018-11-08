using System.Collections.Generic;

namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// The result of a token authentication operation that could have a return value.
    /// </summary>
    /// <typeparam name="T">The type of return value.</typeparam>
    public class AuthResult<T> : AuthResult
    {
        /// <summary>
        /// The return value.
        /// </summary>
        public T Value { get; set; }
    }
    /// <summary>
    /// The result of a token authentication operation.
    /// </summary>
    public class AuthResult
    {
        /// <summary>
        /// Returns a bool of if the operation succeeded.
        /// </summary>
        /// <value></value>
        public bool Succeeded { get; set; }

        /// <summary>
        /// If failed, a collection of error messages is returned.
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();
    }
}