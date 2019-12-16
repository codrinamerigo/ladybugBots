using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using myBots.Models;
using myBots.Views;
using myBots.ViewModels;
using System.Net.Http;
using Newtonsoft.Json;

namespace myBots.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            

           
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();

           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string token;
            
                // Get the token from HTTP Request
                token = await GetBotServiceToken();
            
            await Navigation.PushModalAsync(new myBotWebViewPage(token));
        }

        private async Task<string> GetBotServiceToken()
        {
            HttpClient client = new HttpClient();
            string botKey = Config.WebChatBot;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("BotConnector",botKey); //azure secret

            var url = new Uri("https://webchat.botframework.com/api/tokens");
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                string token = JsonConvert.DeserializeObject<string>(content);


                return token;
            }

            return String.Empty;
        }

        private async void CustomButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomBotPage());
        }
    }
}