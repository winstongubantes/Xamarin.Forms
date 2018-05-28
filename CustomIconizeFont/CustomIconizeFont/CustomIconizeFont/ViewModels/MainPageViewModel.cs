using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CustomIconizeFont.Views;

namespace CustomIconizeFont.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";

            ShowTabbedPageCommand = new DelegateCommand(() =>
            {
                //NavigationService.NavigateAsync(nameof(SampleTabbedPage));
            });
        }

        public ICommand ShowTabbedPageCommand { get; }
    }
}
