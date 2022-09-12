using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using specflow_automation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace specflow_automation.StepDefinitions
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        public string fname;
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

        [When(@"I click on PIM")]
        public void WhenIClickOnPIM()
        {
            AutomationHooks.driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        [When(@"I click on Add Employee")]
        public void WhenIClickOnAddEmployee()
        {
            AutomationHooks.driver.FindElement(By.XPath("//a[text()='Add Employee']")).Click();
        }

        [When(@"I add all details")]
        public void WhenIAddAllDetails(Table table)
        {
            fname = table.Rows[0]["firstname"];
            string mname = table.Rows[0]["middle_name"];
            string lname = table.Rows[0]["last_name"];            
            string tlogind = table.Rows[0]["toggle_login_details"];
            string uname = table.Rows[0]["username"];
            string pass = table.Rows[0]["password"];
            string cpass = table.Rows[0]["confirm_password"];
            string status = table.Rows[0]["status"];

            AutomationHooks.driver.FindElement(By.Name("firstName")).SendKeys(fname);
            AutomationHooks.driver.FindElement(By.Name("middleName")).SendKeys(mname);
            AutomationHooks.driver.FindElement(By.Name("lastName")).SendKeys(lname);

            if (tlogind == "on")
            {
                AutomationHooks.driver.FindElement(By.CssSelector(".oxd-switch-wrapper>label")).Click();
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Username')]/following::input")).SendKeys(uname);
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Password')]/following::input")).SendKeys(pass);
                AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Confirm Password')]/following::input")).SendKeys(cpass);
                if (status.Equals("disabled"))
                {
                    AutomationHooks.driver.FindElement(By.XPath("//label[text()='Disabled']")).Click();
                }
                else
                {
                    AutomationHooks.driver.FindElement(By.XPath("//label[text()='Enabled']")).Click();
                }
            }
        }

        [When(@"I click on save option")]
        public void WhenIClickOnSaveOption()
        {
            AutomationHooks.driver.FindElement(By.XPath("(//button[contains(@class,'oxd-button oxd-button--medium')])[2]")).Click();
        }

        [Then(@"I should navigate to personal details")]
        public void ThenIShouldNavigateToPersonalDetails()
        {
            string actualName=AutomationHooks.driver.FindElement(By.Name("firstName")).GetAttribute("value");
            Assert.Equal(actualName, fname);
        }
    }
}
