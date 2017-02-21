using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CustomLoginHandling.Helpers;
using CustomLoginHandling.Pages;
using Xamarin.Forms;

namespace CustomLoginHandling.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _password;
        private ICommand _loginCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new Command(() =>
            {
                Settings.AuthToken = "probably your authentication token here";

                Application.Current.MainPage.Navigation.InsertPageBefore(new MainPage(), Application.Current.MainPage.Navigation.NavigationStack.Last());
                Application.Current.MainPage.Navigation.PopAsync();
            });}
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
