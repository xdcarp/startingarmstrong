using Microsoft.AspNetCore.Components;

namespace Armstrong.WebClient.Pages
{
    public partial class Authorized : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationState { get; set; }

        private string? userName;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var authState = await AuthenticationState!;
            userName = authState.User.Identity?.Name;
        }
    }
}
