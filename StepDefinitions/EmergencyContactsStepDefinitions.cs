using OpenQA.Selenium;
using specflow_automation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace specflow_automation.StepDefinitions
{
    [Binding]
    public class EmergencyContactsStepDefinitions
    {
        string name;
        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
            AutomationHooks.driver.FindElement(By.XPath("//span[text()='My Info']")).Click();
        }

        [When(@"I click on Emergency Contacts")]
        public void WhenIClickOnEmergencyContacts()
        {
            AutomationHooks.driver.FindElement(By.XPath("//a[text()='Emergency Contacts']")).Click();
        }

        [When(@"I click on Add")]
        public void WhenIClickOnAdd()
        {
            AutomationHooks.driver.FindElement(By.XPath("//button[text()=' Add ']")).Click();
        }

        [When(@"I fill the Add Emergency Contact section")]
        public void WhenIFillTheAddEmergencyContactSection(Table table)
        {
            name = table.Rows[0]["Name"];
            string Relation= table.Rows[0]["Relationship"];
            string Homet= table.Rows[0]["Home_Telephone"];
            string mob= table.Rows[0]["Mobile"];
            string Workt= table.Rows[0]["Work_Telephone"];

            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Name')]/following::input")).SendKeys(name);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Relationship')]/following::input")).SendKeys(Relation);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Home Telephone')]/following::input")).SendKeys(Homet);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Mobile')]/following::input")).SendKeys(mob);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Work Telephone')]/following::input")).SendKeys(Workt);

        }

        [When(@"I click on Save")]
        public void WhenIClickOnSave()
        {
            AutomationHooks.driver.FindElement(By.XPath("//button[text()=' Save ']")).Click();
        }

        [Then(@"I verify the added name")]
        public void ThenIVerifyTheAddedName()
        {
            string actualName = AutomationHooks.driver.FindElement(By.XPath("//div[text()='Name']/following::div")).GetDomAttribute("value");
            Assert.Equal(actualName, name);            
        }
    }
}
