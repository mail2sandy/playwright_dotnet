using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace PlayWrightDemo;

public class PlayRightNunit : PageTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        // Navigate to a URL
        await Page.GotoAsync("http://eaapp.somee.com/");
        await Page.ClickAsync("xpath=//a[@id='loginLink']");
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot.png" // Save the screenshot to a file
        });
        await Page.FillAsync("xpath=//input[@id='UserName']", "admin");
        await Page.FillAsync("xpath=//input[@id='Password']", "password");


        await Page.ClickAsync("xpath=//input[@value='Log in']");

        await Expect(Page.Locator("xpath=//a[text()='Employee Details']")).ToBeVisibleAsync();
        
        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "screenshot_after_login.png" // Save another screenshot after login
        });
    }
}
