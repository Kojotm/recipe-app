using Core.Views;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await FirebaseDatabaseService.LoginAsync();
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
