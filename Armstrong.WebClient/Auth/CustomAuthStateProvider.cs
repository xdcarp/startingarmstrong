using System.Security.Claims;

namespace Armstrong.WebClient.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Nicolas")
            }, "test");

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            return await Task.FromResult(state);
        }
    }
}
