using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlayWrightDemo;

public class Tests
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
        // Navigate to a URL
        await page.GotoAsync("http://eaapp.somee.com/");
        await page.ClickAsync("xpath=//a[@id='loginLink']");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot.png" // Save the screenshot to a file
        });
        await page.FillAsync("xpath=//input[@id='UserName']", "admin");
        await page.FillAsync("xpath=//input[@id='Password']", "password");


        await page.ClickAsync("xpath=//input[@value='Log in']");

        var isExist = await page.IsVisibleAsync("xpath=//a[text()='Employee Details']");
        Assert.That(isExist, Is.True, "Login failed, logout link not found.");
        
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot_after_login.png" // Save another screenshot after login
        });
    }
}
