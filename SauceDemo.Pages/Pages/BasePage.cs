using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using SauceDemo.Customizations.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; private set; }

    protected string BaseUrl { get; private set; }

    public SideBarSection SideBarSection { get; private set; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;

        SideBarSection = new SideBarSection(driver);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        BaseUrl = configuration["ApplicationSettings:BaseUrl"];
}

    public virtual void Open(string relativePath = "")
    {
        Driver.Navigate().GoToUrl(BaseUrl + relativePath);
    }
}
