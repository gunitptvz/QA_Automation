using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
// ReSharper disable All

namespace Demo
{
    public partial class Form1 : Form
    {
        IWebDriver browser;

        private string FindWindow(string url)
        {
            string startwindow = browser.CurrentWindowHandle;
            string result = "";

            for (int i = 0; i < browser.WindowHandles.Count; i++)
            {
                if (browser.WindowHandles[i] != startwindow)
                {
                    browser.SwitchTo().Window(browser.WindowHandles[i]);
                    if (browser.Url.Contains(url))
                    {
                        result = browser.WindowHandles[i];
                        break;
                    }
                }
            }

            browser.SwitchTo().Window(startwindow);
            return result;
        }

        IWebElement GetElement(By locator)
        {
            List<IWebElement> elements = browser.FindElements(locator).ToList();
            if (elements.Count > 0)
            {
                return elements[0];
            }
            else return null;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Use google search button
        {
            browser.Navigate().GoToUrl("https://www.google.com.ua"); // Go to selected URL

            IWebElement searchinput = browser.FindElement(By.XPath(".//*[@id='lst-ib']")); // Find element by XPath
            // Thread.Sleep(5000);
            searchinput.SendKeys("выращиваем грибы дома" + OpenQA.Selenium.Keys.Enter); // Fill search textbox and click Enter
        }

        private void button2_Click(object sender, EventArgs e) // Close web browser button
        {
           browser.Quit(); // Quit browser
        } 

        private void button3_Click(object sender, EventArgs e) // Open web browser button
        {
           // FirefoxProfileManager manage = new FirefoxProfileManager(); // Download user Firefox profile
           // FirefoxProfile profile = manage.GetProfile("myprofile");

        
         browser = new FirefoxDriver(); // Open browser
         browser.Manage().Window.Maximize(); // Maximize browser window
            // browser.Navigate().GoToUrl("https://yandex.ua");
        }

        private void button4_Click(object sender, EventArgs e) // Find element button
        {
            // IWebElement element;

            // Поиск по ID.
            // browser.Navigate().GoToUrl("http://yandex.com.ua");
            // element = browser.FindElement(By.Id("text"));
            // element.SendKeys("тест");

            // Поиск по ClassName.
            // browser.Navigate().GoToUrl("http://mail.ru");
            // element = browser.FindElement(By.ClassName("tb__close__icon-25614543"));
            // element.Click();

            // Поиск по тексту ссылки.
            // browser.Navigate().GoToUrl("http://yandex.com.ua");
            // element = browser.FindElement(By.LinkText("Блог"));
            // element.Click();

            // Поиск по частичному тексту ссылки.
            // browser.Navigate().GoToUrl("http://yandex.com.ua");
            // element = browser.FindElement(By.PartialLinkText("Марк"));

        }

        private void button5_Click(object sender, EventArgs e) // Elements counting button
        {
            browser.Navigate().GoToUrl("http://yandex.com.ua");

            List<IWebElement> news = browser.FindElements(By.XPath(".//*[@id='tabnews_newsc']//li")).ToList(); // Create list of elements and find it

            for(int i = 0; i < news.Count; i++)
            {
                textBox1.AppendText(((i+1).ToString()) + "." + news[i].Text + "." + "\r\n"); // Show list in the texBox form
            }

        }

        private void button6_Click(object sender, EventArgs e) // Find text button
        {
            browser.Navigate().GoToUrl("http://yandex.com.ua");

            List<IWebElement> news = browser.FindElements(By.XPath(".//*[@id='tabnews_newsc']//li")).ToList(); // Create list of elements and find it

            for(int i = 0; i < news.Count; i++)
            {
                string s = news[i].Text;

                if(s.StartsWith("ВСУ")) // News begin on
                {
                    textBox1.AppendText("Новость №" + (i + 1) + " начинается с текста 'ВСУ'" + "\r\n");
                }
                if (s.EndsWith("Дамаска")) // News end of
                {
                    textBox1.AppendText("Новость №" + (i + 1) + " заканчивается текстом 'Дамаска'" + "\r\n");
                }
                if (s.Contains("россияне")) // News constains word
                {
                    textBox1.AppendText("Новость №" + (i + 1) + " содержит текст 'россияне'" + "\r\n");
                    news[i].Click(); // click on finded news
                    break; // stop cicle
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) // Open JS button
        {
            // IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            // js.ExecuteScript("alert('javascript test')");

            IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            js.ExecuteScript(textBox1.Text);
        }

        private void button8_Click(object sender, EventArgs e) // Work with tabs
        {
            /* browser.SwitchTo().Window(browser.WindowHandles[1]); // Show title and url all opened insets.
            MessageBox.Show(browser.Title + "\r\n" + browser.Url);

            browser.SwitchTo().Window(browser.WindowHandles[0]);
            MessageBox.Show(browser.Title + "\r\n" + browser.Url);

            browser.SwitchTo().Window(browser.WindowHandles[2]);
            MessageBox.Show(browser.Title + "\r\n" + browser.Url); */

           /* string habrwindow = FindWindow("habr");
            browser.SwitchTo().Window(habrwindow);
            MessageBox.Show(browser.Title + "\r\n" + browser.Url); */ // Find inset by part of website link.

            List<string> beforetabs = browser.WindowHandles.ToList();
            // открываем новую вкладку.
            List<string> aftertabs = browser.WindowHandles.ToList();
            // вкладки до минус вкладки после = новая вкладка.
            List<string> onenewtab = aftertabs.Except(beforetabs).ToList();
            browser.SwitchTo().Window(onenewtab[0]);
            MessageBox.Show(browser.Title + "\r\n" + browser.Url);
        }

        private void button9_Click(object sender, EventArgs e) // Thread sleep
        {
            browser.Navigate().GoToUrl("http://www.degraeve.com/reference/simple-ajax-example.php");

            IWebElement element = browser.FindElement(By.XPath(".//input[@value = 'Go']"));
            // Thread.Sleep(5000); // плохой способ.
            element.Click();

            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@id='result']")));

            textBox1.Text = txt.Text;
        }

        private void button10_Click(object sender, EventArgs e) // Element existence
        {
            browser.Navigate().GoToUrl("https://modnakasta.ua/");
            IWebElement login = GetElement(By.PartialLinkText("Karta"));
            if (login != null)
            {
                login.Click();
            }
        }
    }
}
