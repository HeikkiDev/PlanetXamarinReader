using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlanetXamarinReader.Views
{
    public class WebPage : ContentPage
    {
        public WebPage(string URL)
        {
            var browser = new WebView();
            browser.Source = URL;
            Content = browser;
        }
    }
}
