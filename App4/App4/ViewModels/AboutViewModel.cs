using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace App4
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://memegenerator.net/img/instances/500x/65346574/its-just-a-prank-bro.jpg")));
        }

        public ICommand OpenWebCommand { get; }
    }
}