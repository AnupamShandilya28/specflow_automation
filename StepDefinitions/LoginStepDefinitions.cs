using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
namespace SpecFlow_Automation
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;
        
        [When(@"I provide username as '([^']*)'")]
        public void WhenIProvideUsernameAs(string username)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
        }
        [When(@"I provide password as '([^']*)'")]
        public void WhenIProvidePasswordAs(string password)
        {
            driver.FindElement(By.Name("password")).SendKeys(password);
        }
        [When(@"I Click on login")]
        public void WhenIClickOnLogin()
        {
            //Console.WriteLine("Click on login");
            driver.FindElement(By.CssSelector("button[Type=submit]")).Click();
        }        
        [Then(@"I should get error message as '([^']*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedError)
        {
            //Console.WriteLine(expectedError);
            String actualError = driver.FindElement(By.CssSelector(".oxd-alert-content-text")).Text;
            Assert.Equal(expectedError, actualError);
        }
        [Then(@"I should navigate to '([^']*)' dashboard screen\+")]
        public void ThenIShouldNavigateToDashboardScreen(string pIM)
        {
            Console.WriteLine(pIM);
        }

    }
}