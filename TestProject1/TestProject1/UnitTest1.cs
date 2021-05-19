using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string url = "https://prd-ruilwinkelvaals.azurewebsites.net/Login/Login";
            ChromeDriver driver = new ChromeDriver(@"D:\School\Vakken\B2C6\TestProject1\TestProject1\bin\Debug\net5.0");
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName("Textbox")).SendKeys("admin@ruilwinkelvaals.nl");
            driver.FindElement(By.ClassName("Textbox")).SendKeys("admin");
            driver.FindElement(By.ClassName("Button")).Click();
            WebDriverWait wait = new WebDriverWait(driver, new System.TimeSpan(0, 0, 10));
            wait.Until(wt => wt.FindElement(By.ClassName("Validation")));
            var message = driver.FindElement(By.ClassName("field-validation-error"));
            Assert.IsTrue(message.Text.Contains("Er is geen wachtwoord ingevuld"));
            driver.Close();
            driver.Dispose();
        }
    }
}
