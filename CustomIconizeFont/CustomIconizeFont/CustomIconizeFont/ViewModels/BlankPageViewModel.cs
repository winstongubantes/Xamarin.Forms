using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CustomIconizeFont.Controls;
using Prism.Navigation;

namespace CustomIconizeFont.ViewModels
{
	public class BlankPageViewModel : ViewModelBase
	{
        public BlankPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoBackCommand = new DelegateCommand(() =>
            {
                NavigationService.NavigateAsync($"app:///{nameof(FlatNavigationPage)}/{nameof(Views.MainPage)}");
            });
        }

	    public ICommand GoBackCommand { get; }

	}
}
