using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using PlaywrightDemo.Pages;

// [Parallelizable(ParallelScope.Self)]
// [TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        LoginPageUpgraded loginPage = new LoginPageUpgraded(Page);
        await loginPage.GoToSignPage();
        await loginPage.Login("admin", "password");
        var WaitForEmployeeResponse = Page.WaitForResponseAsync("**/Employee");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();
        var getResponse = await WaitForEmployeeResponse;
        Assert.That(getResponse.Ok, Is.True, "Employee List API call Success.");
        await Page.GetByRole(AriaRole.Row, new() { Name = "Karthik 4000 24 1 karthik@" }).GetByRole(AriaRole.Link).First.ClickAsync();
        await Expect(Page.Locator("body")).ToContainTextAsync("Hospital");
        await Expect(Page.Locator("body")).ToMatchAriaSnapshotAsync("- heading \"Benefits Listed for Karthik\" [level=2]\n- paragraph\n- heading \"Basic Benefits\" [level=5]\n- table:\n  - rowgroup:\n    - row \"Hospital\":\n      - cell \"Hospital\"\n- table:\n  - rowgroup:\n    - row \"Gym\":\n      - cell \"Gym\"\n- table:\n  - rowgroup:\n    - row \"Dental\":\n      - cell \"Dental\"\n- heading \"Additional Benefits\" [level=5]\n- table:\n  - rowgroup:\n    - row \"Car\":\n      - cell \"Car\"\n- table:\n  - rowgroup:\n    - row \"DriverHire\":\n      - cell \"DriverHire\"\n- table:\n  - rowgroup:\n    - row \"HolidayClaim\":\n      - cell \"HolidayClaim\"\n- paragraph\n- paragraph:\n  - link \"Back to List\":\n    - /url: /Employee\n- separator\n- contentinfo:\n  - paragraph: /© \\d+ - Powered by ExecuteAutomation\\.com/");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Log off" }).ClickAsync();
    }
}
