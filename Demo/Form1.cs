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

namespace Demo
{
    public partial class Form1 : Form
    {
        IWebDriver browser;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser.Navigate().GoToUrl("https://www.google.com.ua"); // Go to selected URL

            IWebElement searchinput = browser.FindElement(By.XPath(".//*[@id='lst-ib']")); // Find element by XPath
            // Thread.Sleep(5000);
            searchinput.SendKeys("выращиваем грибы дома" + OpenQA.Selenium.Keys.Enter); // Fill search textbox and click Enter
        }

        private void button2_Click(object sender, EventArgs e)
        {
           browser.Quit(); // Quit browser
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // FirefoxProfileManager manage = new FirefoxProfileManager(); // Download user Firefox profile
            // FirefoxProfile profile = manage.GetProfile("myprofile"); 

            browser = new FirefoxDriver(); // Open browser
            browser.Manage().Window.Maximize(); // Maximize browser window
            browser.Navigate().GoToUrl("https://yandex.ua");
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            browser.Navigate().GoToUrl("http://yandex.com.ua");

            List<IWebElement> news = browser.FindElements(By.XPath(".//*[@id='tabnews_newsc']//li")).ToList(); // Create list of elements and find it

            for(int i = 0; i < news.Count; i++)
            {
                textBox1.AppendText(((i+1).ToString()) + "." + news[i].Text + "." + "\r\n"); // Show list in the texBox form
            }

        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            // IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            // js.ExecuteScript("alert('javascript test')");

            IJavaScriptExecutor js = browser as IJavaScriptExecutor;
            js.ExecuteScript(textBox1.Text);
        }
    }
}
