using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PlaywrightDemo.Pages;

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
        Page.SetDefaultTimeout(10000);
        // Navigate to a URL
        LoginPage loginPage = new LoginPage(Page);
        await loginPage.GoToSignPage();
        await loginPage.Login("admin", "password");
        await Expect(Page.Locator("xpath=//a[text()='Employee Details']")).ToBeVisibleAsync();
        
    }
}
