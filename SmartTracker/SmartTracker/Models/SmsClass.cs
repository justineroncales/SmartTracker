using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;

namespace SmartTracker.Models
{
    public class SmsTest
    {
        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
        public async Task SendSms()
        {
            var username = "john";
            var password = "Xc3ffs";
            var messagetype = "SMS:TEXT";
            var httpUrl = "https://127.0.0.1:9508/";
            var recipient = HttpUtility.UrlEncode("+639562447811", Encoding.UTF8);
            var messagedata = HttpUtility.UrlEncode("TestMessage", Encoding.UTF8);

            var sendString = $"{httpUrl}api?action=sendmessage&username=" +
                             $"{username}&password={password}" +
                             $"&recipient={recipient}&messagetype=" +
                             $"{messagetype}&messagedata={messagedata}";


            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => { return true; };

            var client = new HttpClient(handler);

            try
            {
                var response = await client.GetStringAsync(sendString);

            }
            catch (Exception e)
            {
            }
        }
    }
}
