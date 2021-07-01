using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace PrihlaseniEmailTest
{
    [Binding]
    public class EmailTestSteps
    {
        IWebDriver driver;
        string uvodnistranka = "https://www.seznam.cz/";
        string cilovaAdresa = "https://email.seznam.cz/?hp=";

        [Given(@"jsem na webu seznam\.cz")]
        public void GivenJsemNaWebuSeznam_Cz()
        {
            driver = new FirefoxDriver();
            driver.Url = uvodnistranka;
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [When(@"jako jmeno zadam (.*)")]
        public void WhenZadamPrihlasovaciJmeno(string jmeno)
        {
            var prihlasJmeno = driver.FindElement(By.Name("username"));
            prihlasJmeno.SendKeys(jmeno);

        }
        [When(@"jako heslo zadam (.*)")]
        public void WhenJakoHesloZadam(string heslo)
        {
            var elementHeslo = driver.FindElement(By.Name("password"));
            elementHeslo.SendKeys(heslo);
        }


        [When(@"jako domenu zadam (.*)")]
        public void WhenZadamHesloAKliknuNaPrihlasit(string domena)
        {
            var elementDomena = driver.FindElement(By.Name("domain"));
            var vybranaDomena = new SelectElement(elementDomena);
            vybranaDomena.SelectByValue(domena);


        }

        [When(@"kliknu na prihlasit")]
        public void WhenKliknuNaPrihlasit()
        {
            var tlacitkoPrihlas = driver.FindElement(By.CssSelector(".input-w-button__button"));
            tlacitkoPrihlas.Click();
            System.Threading.Thread.Sleep(2000);
        }


        [Then(@"bych mel byt na strance mailu")]
        public void ThenBychMelBytNaStranceMailu()
        {
            var aktualniAdresa = driver.Url;
            Assert.That(cilovaAdresa.Contains(aktualniAdresa), Is.True);
        }
        [Then(@"bych mel byt na strance neuspesne prihlaseni")]
        public void ThenBychMelBytNaStranceNeuspesnePrihlaseni()
        {
            var aktualniAdresa = driver.Url;
            Assert.That(!cilovaAdresa.Contains(aktualniAdresa), Is.True);
        }


        [Then(@"zavru prohlizec")]
        public void ThenZavruProhlizec()
        {
            driver.Quit();
        }
    }
}
