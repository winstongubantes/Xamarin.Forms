using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CustomIconizeFont.Controls;
using Prism.Navigation;
using Prism.Services;

namespace CustomIconizeFont.ViewModels
{
	public class SampleContentPageViewModel : ViewModelBase
	{
	    private readonly IPageDialogService _pageDialogService;
        public SampleContentPageViewModel(
            INavigationService navigationService, 
            IPageDialogService pageDialogService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            GoBackCommand = new DelegateCommand(() =>
	        {
	            NavigationService.NavigateAsync($"app:///{nameof(FlatNavigationPage)}/{nameof(Views.MainPage)}");
	        });

            TouchToolbarItemCommand = new DelegateCommand(() =>
            {
                _pageDialogService.DisplayAlertAsync("You touched toolbar item!", "", "Ok");
            });
        }

	    public ICommand GoBackCommand { get; }

        public ICommand TouchToolbarItemCommand { get; }
    }
}
