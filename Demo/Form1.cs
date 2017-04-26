using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Firefox;

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
            browser.Navigate().GoToUrl("https://www.google.com.ua");

            IWebElement searchinput = browser.FindElement(By.XPath(".//input[@id='lst-ib']"));
            searchinput.SendKeys("как вырастить грибы" + OpenQA.Selenium.Keys.Enter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           browser.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            browser = new FirefoxDriver();
            browser.Manage().Window.Maximize();
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
            // browser.Navigate().GoToUrl("http://yandex.com.ua");

            // List<IWebElement> news = browser.FindElements(By.XPath(".//*[@id='tabnews_newsc']//li")).ToList();

            // int a = 1;

            // for(int i = 0; i < news.Count; i++)
            // {
            // textBox1.AppendText((a++) + "." + news[i].Text + "." + "\n");
            // }

        }
    }
}
