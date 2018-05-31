using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CustomPopupDialog.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private ICommand _hideDataEntryCommand;

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";

            SendCommand = new DelegateCommand(Send);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public ICommand HideDataEntryCommand
        {
            get => _hideDataEntryCommand;
            set => SetProperty(ref _hideDataEntryCommand, value);
        }

        public ICommand SendCommand { get; }

        private void Send()
        {
            //DO YOUR LOGIC HERE

            HideDataEntryCommand?.Execute(null);
        }
    }
}
