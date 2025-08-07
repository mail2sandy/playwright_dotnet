using Microsoft.Playwright;
namespace PlaywrightDemo.Driver;

public class Driver : IDisposable
{

    private readonly Task<IPage> _page;
    private IBrowser? _browser;


    public Driver(IPage page)
    {
        _page = initiateDriver();
    }

    public Task<IPage> Page => _page;

    public void Dispose()
    {
        _browser?.CloseAsync();
    }

    public async Task<IPage> initiateDriver()
    {

        using var playwright = await Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50
        });
        // Create a new browser context
        return await _browser.NewPageAsync();
    }

}