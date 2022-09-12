using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace specflow_automation.Hooks
{
    internal class AutomationHooks
    {
        public static IWebDriver driver;

        [AfterScenario]
        public void EndScenario()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

    }
}
