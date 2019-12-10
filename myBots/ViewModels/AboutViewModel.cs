using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace myBots.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/codrinamerigo")));
        }

        public ICommand OpenWebCommand { get; }
    }
}