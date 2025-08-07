using Microsoft.Playwright;

public class Driver : IDisposable
{
    private readonly Task<IPage> _page;
    private IBrowser? _browser;

    public Driver()
    {
        _page = initiateDriver();
    }

    public Task<IPage> Page => _page;

    public void Dispose()
    {
        _browser?.CloseAsync();
    }

    private async Task<IPage> initiateDriver()
    {
        var playwright = await Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Channel = "chrome",
            Headless = false,
            SlowMo = 50 // Optional: slows down operations for better visibility
        });
        // Create a new browser context
        return await _browser.NewPageAsync();
    }
}