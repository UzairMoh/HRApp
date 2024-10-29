using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HRApp.Pages
{
    public partial class Profile
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }
        private string Username = "";
        private string EmailAddress = "";
        private string Picture = "";
        private string IdToken = "";

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthenticationStateTask;

            Username = state.User.Identity.Name ?? string.Empty;
            EmailAddress = state.User.Claims
                .Where(c => c.Type.Equals(System.Security.Claims.ClaimTypes.Email))
                .Select(c => c.Value)
                .FirstOrDefault() ?? string.Empty;

            Picture = state.User.Claims
                .Where(c => c.Type.Equals("picture"))
                .Select(c => c.Value)
                .FirstOrDefault() ?? string.Empty;

            IdToken = tokenProvider.IdToken;

            await base.OnInitializedAsync();
        }
    }
}