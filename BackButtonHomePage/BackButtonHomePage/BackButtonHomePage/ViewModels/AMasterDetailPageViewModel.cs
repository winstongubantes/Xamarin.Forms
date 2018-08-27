using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using BackButtonHomePage.Views;
using Prism.Navigation;
using Xamarin.Forms;

namespace BackButtonHomePage.ViewModels
{
	public class AMasterDetailPageViewModel : BindableBase
	{
	    private INavigationService _navigationService;

        public AMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

	    public void NavigateHome()
	    {
	        _navigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
	    }

	    private ICommand _navigateCommand;
	    public ICommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(NavigateCmd));

	    private void NavigateCmd(string obj)
	    {
	        _navigationService.NavigateAsync($"{nameof(NavigationPage)}/{obj}");
        }
	}
}
