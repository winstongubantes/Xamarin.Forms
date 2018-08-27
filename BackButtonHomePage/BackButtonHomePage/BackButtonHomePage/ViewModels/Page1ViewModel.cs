using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackButtonHomePage.ViewModels
{
	public class Page1ViewModel : BindableBase, IBackButtonAware
    {
        public bool OnBackButtonPressed()
        {
            return false; // We are telling the system to go to Home Page instead of Device's Home 
        }
    }
}
