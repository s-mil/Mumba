namespace SamMiller.Mumba.Api.Infrastructure.Identity
{
    /// <summary>
    /// The clsass that defines the AuthOptions passed in AuthDbContext
    /// </summary>
    public class AuthOptions
    {
        /// <summary>
        /// The secret key to sign authentication tokens with.
        /// </summary>
        public string TokenSigningKey { get; set; }

        /// <summary>
        /// The lifetime of an access token in hours.
        /// </summary>
        public int AccessTokenLifetimeHours { get; set; }

        /// <summary>
        /// The lifetime of a refresh token in days.
        /// </summary>
        public int RefreshTokenLifetimeDays { get; set; }
    }
}