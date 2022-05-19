using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void helicopter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportPage(), false);
        }

        private async void weather_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherPage(), false);
        }
    }
}
