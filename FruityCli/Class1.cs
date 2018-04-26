using System;
using System.Linq.Expressions;
using OpenQA.Selenium;

namespace Floozy
{
    public class FloozyDriver
    {
        private IWebDriver _webDriver;

        public FloozyPage<T> Load<T> (string url) where T : class
        {
            return new FloozyPage<T>(null);
        }
        
    }    

    public class FloozyPage<TPageModel> where TPageModel : class
    {
        private readonly TPageModel _pageModel;
        public FloozyPage(TPageModel pageModel)
        {
            _pageModel = pageModel;
        }        

        public FloozyInput<TPageModel> Type(string keysToType)
        {
            return new FloozyInput<TPageModel>(this, keysToType);
        }

        public FloozyExpectation<TPageModel> Click<TProperty>(Expression<Func<TPageModel, TProperty>> property)
        {
            throw new NotImplementedException();
        }
    }

    public class FloozyExpectation<TPageModel> where TPageModel : class
    {

    }

    public class FloozyInput<TPageModel> where TPageModel : class
    {
        private readonly FloozyPage<TPageModel> _page;
        public FloozyInput(FloozyPage<TPageModel> page, string text)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
        }

        public FloozyPage<TPageModel> Into<TProperty>(Expression<Func<TPageModel, TProperty>> property)
        {
            return _page;
        }
    }

    public class HomePageModel
    {
        public Func<IWebDriver, IWebElement> UserName => d => d.FindElement(By.Id("userName"));
        public Func<IWebDriver, IWebElement> Password => d => d.FindElement(By.Id("password"));
        public Func<IWebDriver, IWebElement> SubmitButton => d => d.FindElement(By.Id("submit"));
    }

    public class Test
    {
        public void RunTest()
        {
            var floozy = new FloozyDriver();
            floozy
                .Load<HomePageModel>("http://localhost")
                .Type("vincent")
                .Into(p => p.UserName)
                .Type("password1234")
                .Into(p => p.Password)
                .Click(p => p.SubmitButton);
        }
    }
}
