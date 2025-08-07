using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class LoginPageUpgraded
{

    private readonly IPage _page;
    public LoginPageUpgraded(IPage page) =>_page = page;

    private const string LoginUrl = "http://eaapp.somee.com/";
    private ILocator _loginLink => _page.Locator("a", new PageLocatorOptions { HasTextString = "Login" });
    private ILocator _usernameField => _page.Locator("xpath=//input[@id='UserName']");
    private ILocator _passwordField => _page.Locator("xpath=//input[@id='Password']");
    private ILocator _loginButton => _page.Locator("xpath=//input[@value='Log in']");
    private ILocator _employeeDetailsLink => _page.Locator("xpath=//a[text()='Employee Details']");
    private ILocator _logoutLink => _page.Locator("xpath=//a[text()='Log off']");


    public async Task GoToSignPage()
    {
        await _page.GotoAsync(LoginUrl);
        await _loginLink.ClickAsync();
    }

    public async Task Login(string username, string password)
    {
        await _usernameField.FillAsync(username);
        await _passwordField.FillAsync(password);
        await _loginButton.ClickAsync();
    }

}