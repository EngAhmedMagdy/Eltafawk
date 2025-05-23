using System.Security.Claims;

public class CustomAuthenticationService
{
    private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

    public ClaimsPrincipal CurrentUser => _currentUser;

    public event Action<ClaimsPrincipal>? UserChanged;

    public async Task SignInAsync(string userId, string fullName, string email)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, fullName),
            new Claim(ClaimTypes.Email, email)
        }, "CustomAuth");

        _currentUser = new ClaimsPrincipal(identity);

        // TODO: Persist to localStorage or elsewhere if needed
        UserChanged?.Invoke(_currentUser);
    }

    public void SignOut()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        UserChanged?.Invoke(_currentUser);
    }

    // Optional: Load previous session from localStorage or other storage
    public async Task InitializeAsync()
    {
        // TODO: Load stored user from persistent storage
        // _currentUser = loadedUser;
        UserChanged?.Invoke(_currentUser);
    }
}
