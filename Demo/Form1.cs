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
            browser = new OperaDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://www.google.com.ua");

            IWebElement searchinput = browser.FindElement(By.XPath(".//input[@id='lst-ib']"));
            searchinput.SendKeys("как вырастить грибы" + OpenQA.Selenium.Keys.Enter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           browser.Quit();
        }
    }
}
