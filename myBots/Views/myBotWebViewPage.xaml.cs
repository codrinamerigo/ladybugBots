using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBots.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class myBotWebViewPage : ContentPage
    {
        public myBotWebViewPage(string token)
        {
            InitializeComponent();

            string botWebViewUrl = "https://webchat.botframework.com/embed/LadyBugBot?s=" + token;
            this.myBotWebView.Source = botWebViewUrl;
            
        }
    }
}