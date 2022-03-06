using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using BLL.DTOs.People.User;
using BLL.Facades.User;

namespace BlazorServerUI.Authentication
{
    /// <summary>
    /// Custom authentication provider that uses session storage
    /// </summary>
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        // session storage that is used to store login data during a single session
        private readonly ISessionStorageService sessionStorageService;
        
        private readonly IUserManagementFacade userFacade;

        /// <summary>
        /// Constructs and custom auth provider from session storage and user facade
        /// </summary>
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService, 
            IUserManagementFacade userFacade)
        {
            this.sessionStorageService = sessionStorageService;
            this.userFacade = userFacade;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {   
            var id = await sessionStorageService.GetItemAsync<int?>("id");           
            
            ClaimsIdentity identity;
            
            if (id != null)
            {
                var user = await userFacade.GetAsync((int)id);
                identity = GetClaimsIdentity(user);
            }
            else
            {
                identity = GetDefaultClaimsIdentity();
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);            

            return new AuthenticationState(claimsPrincipal);
        }

        /// <summary>
        /// Asynchronously marks user as authenticated
        /// </summary>
        /// <param name="user"> valid UserInfoDTO with valid fields </param>
        public async Task MarkUserAsAuthenticated(UserInfoDTO user)
        {
            await sessionStorageService.SetItemAsync("id", user.Id);

            var identity = GetClaimsIdentity(user);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        /// <summary>
        /// Asynchronously marks currently logged in user as logged out.
        /// </summary>
        public async Task MarkUserAsLoggedOut()
        {
            await sessionStorageService.RemoveItemAsync("id");

            var identity = GetDefaultClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        // gets default claims identity to be used for logged out users
        private ClaimsIdentity GetDefaultClaimsIdentity()
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, "LoggedOut"), 
            });
        }

        // gets claims identity for given user
        private ClaimsIdentity GetClaimsIdentity(UserInfoDTO user)
        {
            if (user == null)
            {
                return GetDefaultClaimsIdentity();
            }
            
            var roles = user.Role.ToString("F").
                Split(',').
                Select(s => new Claim(ClaimTypes.Role, s.Trim()));
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Gender, user.Gender.ToString("D")),
                new Claim(ClaimTypes.DateOfBirth, user.Birth.ToString()),
            };
            claims.AddRange(roles);
            return new ClaimsIdentity(claims, "baseauth_type");
        }
    }
}