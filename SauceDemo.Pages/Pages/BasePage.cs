using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using SauceDemo.Customizations.Pages;
using SauceDemo.Customizations;

public abstract class BasePage
{
    protected IWebDriver Driver { get; private set; }

    protected string BaseUrl { get; private set; }

    public SideBarSection SideBarSection { get; private set; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;

        SideBarSection = new SideBarSection(driver);

        BaseUrl = Configuration.BaseUrl;
    }

    public virtual void Open(string relativePath = "")
    {
        Driver.Navigate().GoToUrl(BaseUrl + relativePath);
    }
}
