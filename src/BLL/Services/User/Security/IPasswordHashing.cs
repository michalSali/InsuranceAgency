using System;

namespace BLL.Services.User.Security
{
    /// <summary>
    /// Defines an interface for security password hashing operations used for user.
    /// </summary>
    public interface IPasswordHashing
    {
        /// <summary>
        /// Gets password and salt from a passwordHash
        /// </summary>
        /// <param name="passwordHash"> hashed password by <see cref="CreateHash"/></param>
        /// <returns> password and salt strings </returns>
        (string, string) GetPassAndSalt(string passwordHash);

        /// <summary>
        /// Verifies whether hashed password matches salt and password
        /// </summary>
        /// <param name="passwordHash"> password hashed by <see cref="CreateHash"/></param>
        /// <param name="salt"> salt to be used for password </param>
        /// <param name="password"> password given by user to verify </param>
        /// <returns> true if password can be with salt hashed to passwordHash </returns>
        bool VerifyHashedPassword(string passwordHash, string salt, string password);

        /// <summary>
        /// Creates a hash from password
        /// </summary>
        /// <param name="password"> password given by user </param>
        /// <returns> salt and hash </returns>
        Tuple<string, string> CreateHash(string password);
    }
}