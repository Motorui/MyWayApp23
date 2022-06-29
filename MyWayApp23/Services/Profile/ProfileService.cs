namespace MyWayApp23.Services.Profile;

public record Preferences
{
    public bool DarkMode { get; init; }
}

public class ProfileService
{
    private readonly ILocalStorageService _localStorageService;

    public ProfileService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public event Action<Preferences>? OnChange;

    public async Task ToggleDarkMode()
    {
        var preferences = await GetPreferences();
        var newPreferences = preferences
            with
        { DarkMode = !preferences.DarkMode };

        await _localStorageService!.SetItemAsync("preferences", newPreferences);
        OnChange?.Invoke(newPreferences);
    }

    public async Task SetTheme()
    {
        var preferences = await GetPreferences();
        var newPreferences = preferences
            with
        { DarkMode = !preferences.DarkMode };
        await _localStorageService.SetItemAsync<Preferences>("preferences", newPreferences);
    }

    public async Task<Preferences> GetPreferences()
    {
        return await _localStorageService.GetItemAsync<Preferences>("preferences");
    }
}