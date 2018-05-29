using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CustomIconizeFont.Views;
using Prism.Services;

namespace CustomIconizeFont.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService _pageDialogService;

        public MainPageViewModel(
            INavigationService navigationService, 
            IPageDialogService pageDialogService) 
            : base (navigationService)
        {
            _pageDialogService = pageDialogService;
            Title = "Main Page";

            ShowNavigation = new DelegateCommand<string>(path =>
                {
                    NavigationService.NavigateAsync(path);
                });
        }

        public ICommand ShowNavigation { get; }
    }
}
