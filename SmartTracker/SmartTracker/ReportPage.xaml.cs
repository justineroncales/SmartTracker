using Plugin.Geolocator;
using Plugin.Messaging;
using SmartTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        public ReportPage()
        {
            InitializeComponent();
        }
        private async void Send1_Clicked(object sender, EventArgs e)
        {
            //SmsTest _sms = new SmsTest();
            //    await _sms.SendSms();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            var location = "http://maps.google.com/?q=" + position.Latitude.ToString() +","+position.Longitude.ToString();
            var sms = Message.Text.ToString() + "\n" + location.ToString().Replace("\n", System.Environment.NewLine);
            var message = new SmsMessage(sms, "09082279193");
            await Sms.ComposeAsync(message);
        }
    }
}