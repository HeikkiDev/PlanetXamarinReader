using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PlanetXamarinReader.Views
{
    public partial class PlanetXamarinRSSPage : ContentPage
    {
        public PlanetXamarinRSSPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            Models.RSSFeed rssItem = (Models.RSSFeed)e.SelectedItem;

            if (!string.IsNullOrEmpty(rssItem.link.Trim()))
            {
                var webViewPage = new Views.WebPage(rssItem.link);
                await Navigation.PushAsync(webViewPage, true);
            }

            //Disabling Selection...
            ((ListView)sender).SelectedItem = null;
        }
    }
}
