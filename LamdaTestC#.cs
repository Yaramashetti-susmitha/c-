using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace lambdatestCsharp
{
    
    
    
        [TestFixture("chrome", "88.0", "windows 10")]
        [TestFixture("firefox", "82.0", "windows 7")]
        [TestFixture("internet explorer", "11.0", "windows 10")]
        [TestFixture("edge", "87.0", "macOS Sierra")]

        public class TestClass
        {
            private IWebDriver driver = null;
            private string browser;  
            private string version;
            private string os;

            public TestClass(String browser, String version, String os)
            {
                this.browser = browser;
                this.version = version;
                this.os = os;
            }

            [SetUp]
            public void init()
            {
                String username = "susmithavarma733";
                String accesskey = "6w7Qw7t3krNKItvr8UTfl0Trh7q94QxureEY4iPYfvmRfbYCK6";

                DesiredCapabilities capabilities = new DesiredCapabilities();

                capabilities.SetCapability("user", username);
                capabilities.SetCapability("accessKey", accesskey);
                capabilities.SetCapability("browserName", browser);
                capabilities.SetCapability("version", version);
                capabilities.SetCapability("platform", os);
                capabilities.SetCapability("name", "SeleniumCSharp");
                capabilities.SetCapability("build", "CSharp");

                driver = new RemoteWebDriver(new Uri("https://susmithavarma733:6w7Qw7t3krNKItvr8UTfl0Trh7q94QxureEY4iPYfvmRfbYCK6@hub.lambdatest.com/wd/hub"), capabilities, TimeSpan.FromSeconds(600));

            }

            [Test]
            public void check_Demo()
            {
                driver.Url = "https://www.lambdatest.com/selenium-playground";
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
                IWebElement email = driver.FindElement(By.CssSelector("#__next > div.wrapper > section.my-50 > div > div > div:nth-child(1) > div:nth-child(1) > ul > li:nth-child(1) > a"));
                email.Click();
                driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
                String currentURL = driver.Url;
                if (currentURL.Contains("simple-form-demo"))
                    Console.WriteLine("Yes");


                else
                {
                    Console.WriteLine("No");
                }
                String msg = "Welcome to LambdaTest";
                driver.FindElement(By.XPath("//input[@id='user-message']")).SendKeys(msg);
                driver.FindElement(By.XPath("//button[@id='showInput']")).Click();
                IWebElement msg2 = driver.FindElement(By.XPath("//p[@id='message']"));
                if (msg2.Equals(msg))
                {
                    Console.WriteLine("Yes");
                }
                Thread.Sleep(2000);
                driver.Quit();
            }
            [Test]
            public void Drag()
            {
                driver.Url = "https://www.lambdatest.com/selenium-playground";
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
                driver.FindElement(By.CssSelector("#__next > div.wrapper > section.my-50 > div > div > div:nth-child(1) > div:nth-child(2) > ul > li:nth-child(3) > a")).Click();
                driver.FindElement(By.CssSelector("span[class='cookie__bar__close hover:underline smtablet:hidden']")).Click();
                IWebElement middle = driver.FindElement(By.XPath("//div[@id='slider3']/div/input[@class='sp__range']"));
                var action = new Actions(driver);
                action
                  .DragAndDropToOffset(middle, 119, 0)
                  .Build()
                  .Perform();
                Thread.Sleep(2000);
                IWebElement range = driver.FindElement(By.Id("rangeSuccess"));
                Console.WriteLine(range);
                if (range.Equals("95"))
                {
                    Console.WriteLine("Same value is displayed in the rangesuccess");

                }
                else
                {
                    Console.WriteLine("Same value is not displayed in the rangesuccess");
                }
                //Assert.assertEquals("95", range);
                driver.Quit();
            }

            [Test]
            public void input_Demo()
            {

                driver.Url = "https://www.lambdatest.com/selenium-playground";
                Thread.Sleep(2000);
                IJavaScriptExecutor form = (IJavaScriptExecutor)driver;
                IWebElement fill = driver.FindElement(By.LinkText("Input Form Submit"));
                form.ExecuteScript("arguments[0].click()", fill);
                driver.FindElement(By.Id("name")).SendKeys("susmitha");
                driver.FindElement(By.Id("inputEmail4")).SendKeys("susmitha@gmail.com");
                driver.FindElement(By.Id("inputPassword4")).SendKeys("1234567890");
                driver.FindElement(By.Id("company")).SendKeys("lambda");
                driver.FindElement(By.Id("websitename")).SendKeys("lambdates.com");
                SelectElement country = new SelectElement(driver.FindElement(By.Name("country")));
                country.SelectByText("United States");
                driver.FindElement(By.Id("inputCity")).SendKeys("CBE");
                driver.FindElement(By.Id("inputAddress1")).SendKeys("no 15, old sathy road");
                driver.FindElement(By.Id("inputAddress2")).SendKeys("Tirupathi");
                driver.FindElement(By.Id("inputState")).SendKeys("Chennai");
                driver.FindElement(By.Id("inputZip")).SendKeys("641006");
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                var msg = "Thanks for contacting us, we will get back to you shortly.";
                String hidMsg = driver.FindElement(By.CssSelector("p[class='success-msg hidden']")).Text;
                //Assert.AreSame(hidMsg, msg);
                if (hidMsg.Equals(msg))
                {
                    Console.WriteLine(hidMsg);

                }
                else
                {
                    Console.WriteLine("Not as expected");
                }

                driver.Quit();
            }
        }
    }