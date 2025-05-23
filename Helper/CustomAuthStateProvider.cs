using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly CustomAuthenticationService _service;

    public CustomAuthStateProvider(CustomAuthenticationService service)
    {
        _service = service;

        _service.UserChanged += (newUser) =>
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(newUser)));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = _service.CurrentUser ?? new ClaimsPrincipal(new ClaimsIdentity());
        return Task.FromResult(new AuthenticationState(user));
    }
}
