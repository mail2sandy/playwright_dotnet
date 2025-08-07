using TechTalk.SpecFlow;
using Microsoft.Playwright;
using MySpecFlowProject.Pages; // Add this if LoginPage is in PlaywrightDemo.Pages namespace
using TechTalk.SpecFlow.Assist;
using System.Runtime.CompilerServices;
using Allure.NUnit;
namespace MySpecFlowProject.Steps;

[Binding]
[AllureNUnit]
public class EATestSteps
{
    private readonly Driver _driver;
    private LoginPage _loginPage;

    public EATestSteps(Driver driver)
    {
        _driver = driver;
    }

    [BeforeScenario]
    public async Task InitializeAsync()
    {
        var page = await _driver.Page;
        _loginPage = new LoginPage(page);
    }
    [Given(@"I navigate to the EAE Test App page")]
    public async Task GivenINavigateToTheEATestPage()
    {
        await _loginPage.NavigateToLoginPage();
    }

    [Given(@"I click on the Login link")]
    public async Task GivenClickOnTheLoginLink()
    {
       await _loginPage.ClickSignPage();
    }

    [Given(@"I enter following credentials:")]
    public async Task GivenIEnterBelowCredentials(Table table)
    {
        dynamic credentials = table.CreateDynamicInstance();
        string username = credentials.UserName;
        string password = credentials.Password;
        await _loginPage.Login(username, password);
    }

    [Then(@"I see EMP list link")]
    public async Task ThenIShouldEmpList()
    {
        bool res = await _loginPage.IsEmployeeDetailsLinkVisible();
        if (!res)
        {
            throw new Exception("Employee Details link is not visible");
        }else
        {
            Console.WriteLine("Employee Details link is visible");
        }
    }
}