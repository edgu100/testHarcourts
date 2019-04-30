using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;

namespace Assignment_D

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int totalCities = 0;
            int totalRegions = 0;
            IWebDriver driver = new ChromeDriver();
            TextWriter tw = new StreamWriter("C:/Users/edgu1/Desktop/333.txt");
            driver.Navigate().GoToUrl(" http://www.harcourts.co.nz/ ");
            IWebElement houseRegion = driver.FindElement(By.XPath("//*[@id='homeFeature']/form/ul/li[2]/ul[1]/li[1]/select"));
            SelectElement region =new SelectElement( houseRegion);


            foreach (IWebElement selectCity in region.Options)
            {
                region.SelectByText("all regions");
                if (selectCity.Text.Equals("all regions")) continue;
                totalRegions++;
                tw.WriteLine(selectCity.Text);
                region.SelectByText(selectCity.Text);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//*[@id='homeFeature']/form/ul/li[2]/ul[1]/li[2]/select"))));
                IWebElement TownElement = driver.FindElement(By.XPath("//*[@id='homeFeature']/form/ul/li[2]/ul[1]/li[2]/select"));
                SelectElement towns = new SelectElement( TownElement);

                foreach (IWebElement m in towns.Options)
                {
                    if (m.Text.Equals("all districts")) continue;
                    totalCities++;
                    tw.WriteLine("--" + m.Text);
                }
            }

            tw.WriteLine("----------------------Totals-------------------");
            tw.WriteLine("total number of makes" + totalRegions);
            tw.WriteLine("total number of models" + totalCities);
            tw.Close();
            driver.Quit();
        }
    }
}
