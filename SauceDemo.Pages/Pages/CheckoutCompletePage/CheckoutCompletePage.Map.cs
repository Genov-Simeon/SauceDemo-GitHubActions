using OpenQA.Selenium;

namespace SauceDemo.Customizations.Pages
{
    public partial class CheckoutCompletePage
    {
        public IWebElement CheckoutCompleteTitle => Driver.FindElement(By.ClassName("title"));
        
        public IWebElement CompleteHeader => Driver.FindElement(By.ClassName("complete-header"));
        
        public IWebElement CompleteText => Driver.FindElement(By.ClassName("complete-text"));
        
        public IWebElement PonyExpressImage => Driver.FindElement(By.ClassName("pony_express"));
        
        public IWebElement BackHomeButton => Driver.FindElement(By.Id("back-to-products"));
    }
}
