using System;
using System.Collections.Generic;
using System.Text;

namespace BackButtonHomePage.ViewModels.Base
{
    public interface IBackButtonAware
    {
        bool OnBackButtonPressed();
    }
}
