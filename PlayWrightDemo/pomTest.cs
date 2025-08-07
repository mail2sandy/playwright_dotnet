using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightDemo.Pages;

namespace PlayWrightDemo;

public class POMTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        // Initialize Playwright and launch a browser
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // Set to true to run in headless mode
        });
        var page = await browser.NewPageAsync();
        // Navigate to a URLand signin
        LoginPage loginPage = new LoginPage(page);
        await loginPage.GoToSignPage();
        await loginPage.Login("admin", "password");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot.png" // Save the screenshot to a file
        });
        
        var isExist = await page.IsVisibleAsync("xpath=//a[text()='Employee Details']");
        Assert.That(isExist, Is.True, "Login failed, logout link not found.");
        
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot_after_login.png" // Save another screenshot after login
        });
    }
}
