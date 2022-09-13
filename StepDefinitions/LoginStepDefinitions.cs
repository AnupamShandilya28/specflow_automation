using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using specflow_automation.Hooks;
using System;
using TechTalk.SpecFlow;
namespace SpecFlow_Automation
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Given(@"I have browser with orangehrm page")]
        public void GivenIHaveBrowserWithOrangehrmPage()
        {
            // Console.WriteLine("orangehrm page");
            AutomationHooks.driver = new ChromeDriver();
            AutomationHooks.driver.Manage().Window.Maximize();
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AutomationHooks.driver.Url = "https://opensource-demo.orangehrmlive.com/";
        }

        [When(@"I enter username as '([^']*)'")]
        public void WhenIEnterUsernameAs(string admin)
        {
            AutomationHooks.driver.FindElement(By.Name("username")).SendKeys(admin);
        }

        [When(@"I enter password as '([^']*)'")]
        public void WhenIEnterPasswordAs(string p0)
        {
            AutomationHooks.driver.FindElement(By.Name("password")).SendKeys(p0);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            AutomationHooks.driver.FindElement(By.CssSelector("button[Type=submit]")).Click();
        }
        [Then(@"I should get error message as '([^']*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedError)
        {
            //Console.WriteLine(expectedError);
            String actualError = AutomationHooks.driver.FindElement(By.CssSelector(".oxd-alert-content-text")).Text;
            Assert.Equal(expectedError, actualError);
        }
        [Then(@"I should navigate to '([^']*)' dashboard screen\+")]
        public void ThenIShouldNavigateToDashboardScreen(string pIM)
        {
            Console.WriteLine(pIM);
        }

    }
}