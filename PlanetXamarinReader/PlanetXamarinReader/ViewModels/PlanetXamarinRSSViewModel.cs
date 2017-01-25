using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace PlanetXamarinReader.ViewModels
{
    class PlanetXamarinRSSViewModel : INotifyPropertyChanged

    {
        private Services.RSSFeedAPIService rssFeedAPIService = new Services.RSSFeedAPIService();

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        private List<Models.RSSFeed> rssFeedCollection;
        public List<Models.RSSFeed> RssFeedCollection
        {
            get { return rssFeedCollection; }
            set
            {
                rssFeedCollection = value;
                OnPropertyChanged();
            }
        }

        // Constructor
        public PlanetXamarinRSSViewModel()
        {
            ExecuteGetPlanetXamarinRSSCommand();
        }

        /*ICommand getRestaurants;
        public ICommand GetRestaurantsCommand =>
                getRestaurants ??
                (getRestaurants = new Command(async () => await ExecuteGetRestaurantsCommand()));*/

        private Command getRSSPlanetXamarinFeed;

        public Command GetRSSFeedPlanetXamarinCommand
        {
            get
            {
                return getRSSPlanetXamarinFeed ?? (getRSSPlanetXamarinFeed = new Command(ExecuteGetPlanetXamarinRSSCommand, () =>
                {
                    return !IsBusy;
                }));
            }
        }

        private async void ExecuteGetPlanetXamarinRSSCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            GetRSSFeedPlanetXamarinCommand.ChangeCanExecute();
            try
            {
                RssFeedCollection = await rssFeedAPIService.GetPlanetXamarinRSSFeed();
            }
            catch
            {
                RssFeedCollection = null;
            }
            finally
            {
                IsBusy = false;
                GetRSSFeedPlanetXamarinCommand.ChangeCanExecute();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
