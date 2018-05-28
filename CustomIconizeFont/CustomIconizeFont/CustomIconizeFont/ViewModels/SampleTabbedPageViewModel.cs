using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace CustomIconizeFont.ViewModels
{
	public class SampleTabbedPageViewModel : ViewModelBase
    {
        public SampleTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Tab Page";
        }
    }
}
