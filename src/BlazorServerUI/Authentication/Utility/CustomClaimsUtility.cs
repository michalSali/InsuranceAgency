using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BLL.DTOs.Enums;
using BLL.DTOs.People.User;

namespace BlazorServerUI.Authentication.Utility
{
    /// <summary>
    /// Static class that contains utility function to work with claims from <see cref="CustomAuthenticationStateProvider"/>
    /// </summary>
    public static class CustomClaimsUtility
    {
        /// <summary>
        /// Extracts user id from ClaimsPrincipal user
        /// </summary>
        /// <param name="user"> ClaimsPrincipal user retrieved from AuthenticationState </param>
        /// <returns> integer id, -1 if not found </returns>
        public static int ExtractClaimsId(ClaimsPrincipal user)
        {
            return int.Parse(ExtractClaimsRawByTypeFirst(user, ClaimTypes.NameIdentifier) ?? "-1");
        }

        /// <summary>
        /// Extracts user name from ClaimsPrincipal user
        /// </summary>
        /// <param name="user"> ClaimsPrincipal user retrieved from AuthenticationState </param>
        /// <returns> string name, can be null if not found </returns>
        public static string ExtractClaimsName(ClaimsPrincipal user)
        {
            return ExtractClaimsRawByTypeFirst(user, ClaimTypes.Name);
        }

        /// <summary>
        /// Extracts user role from ClaimsPrincipal user
        /// </summary>
        /// <param name="user"> ClaimsPrincipal user retrieved from AuthenticationState </param>
        /// <returns> user role </returns>
        public static UserRoleDTO ExtractClaimsRole(ClaimsPrincipal user)
        {
            var roles = ExtractClaimsRawByType(user, ClaimTypes.Role);
            string concatRole;
            if (roles == null || roles.Any())
            {
                concatRole = "None";
            }
            else
            {
                concatRole = string.Join(", ", roles);
            }
            return Enum.Parse<UserRoleDTO>(concatRole);
        }

        /// <summary>
        /// Extracts user information from ClaimsPrincipal user
        /// </summary>
        /// <param name="user"> ClaimsPrincipal user retrieved from AuthenticationState </param>
        /// <returns> user info </returns>
        public static UserInfoDTO ExtractClaimsUserInfoDto(ClaimsPrincipal user)
        {
            try
            {
                var result = new UserInfoDTO();
                result.Birth = ExtractClaimsBirth(user);
                result.Gender = ExtractClaimsGender(user);
                result.Name = ExtractClaimsName(user);
                result.Role = ExtractClaimsRole(user);
                result.Id = ExtractClaimsId(user);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // extracts birth datetime from ClaimsPrincipal user
        private static DateTime ExtractClaimsBirth(ClaimsPrincipal user)
        {
            return DateTime.Parse(ExtractClaimsRawByTypeFirst(user, ClaimTypes.DateOfBirth));
        }

        // Extracts gender from ClaimsPrincipal user
        private static Gender ExtractClaimsGender(ClaimsPrincipal user)
        {
            return (Gender)int.Parse(ExtractClaimsRawByTypeFirst(user, ClaimTypes.Gender) ?? "0");
        }

        // Extracts first string with given type from ClaimsPrincipal user
        private static string ExtractClaimsRawByTypeFirst(ClaimsPrincipal user, string type)
        {
            return ExtractClaimsRawByType(user, type).FirstOrDefault();
        }

        // Extracts all strings with given type from ClaimsPrincipal user
        private static IEnumerable<string> ExtractClaimsRawByType(ClaimsPrincipal user, string type)
        {
            return user.Claims?.Where(claim => claim.Type == type).Select(claim => claim.Value).ToList() 
                   ?? new List<string>();
        }
    }
}