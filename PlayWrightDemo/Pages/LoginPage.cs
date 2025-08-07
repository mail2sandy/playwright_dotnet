using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class LoginPage
{

    private readonly IPage _page;
    private const string LoginUrl = "http://eaapp.somee.com/";
    private readonly ILocator _loginLink;
    private readonly ILocator _usernameField;
    private readonly ILocator _passwordField;
    private readonly ILocator _loginButton;
    private readonly ILocator _employeeDetailsLink;
    private readonly ILocator _logoutLink;

    public LoginPage(IPage page)
    {
        _page = page;
        _loginLink = _page.Locator("a", new PageLocatorOptions { HasTextString = "Login" });
        _usernameField = _page.Locator("xpath=//input[@id='UserName']");
        _passwordField = _page.Locator("xpath=//input[@id='Password']");
        _loginButton = _page.Locator("xpath=//input[@value='Log in']");
        _employeeDetailsLink = _page.Locator("xpath=//a[text()='Employee Details']");
        _logoutLink = _page.Locator("xpath=//a[text()='Log off']");

    }

    public async Task GoToSignPage()
    {
        await _page.GotoAsync(LoginUrl);

        if (await _loginLink.IsVisibleAsync())
        {
            await Task.WhenAll(
                _loginLink.ClickAsync(),
                _page.WaitForURLAsync("**/Login")
            );
        }
    }

    public async Task Login(string username, string password)
    {
        await _usernameField.FillAsync(username);
        await _passwordField.FillAsync(password);
        await _loginButton.ClickAsync();
    }

}