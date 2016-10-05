using System.Linq;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Component.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && !string.IsNullOrEmpty(e.Parameter.ToString()))
            {
                string parameter = e.Parameter.ToString();
                string address = Uri.UnescapeDataString(parameter);
                MapLocationFinderResult result = await MapLocationFinder.FindLocationsAsync(address, null);
                Geopoint point = result.Locations.FirstOrDefault().Point;

                MapIcon icon = new MapIcon
                {
                    Location = point,
                    Title = "Palazzo del ghiaccio"
                };

                Map.MapElements.Add(icon);

                await Map.TrySetViewAsync(point, 15);

                ApplicationData.Current.LocalSettings.Values["coordinates"] = $"{point.Position.Latitude}, {point.Position.Longitude}";
            }
        }
    }
}
