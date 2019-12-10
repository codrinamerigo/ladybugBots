using myBots.ViewModels;
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
    public partial class CustomBotPage : ContentPage
    {
        private BotViewModel ViewModel;

        public CustomBotPage()
        {
            InitializeComponent();

            ViewModel = new BotViewModel();
            BindingContext = ViewModel;
        }
    }
}