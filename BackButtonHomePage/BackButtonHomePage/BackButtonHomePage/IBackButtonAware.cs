using System;
using System.Collections.Generic;
using System.Text;

namespace BackButtonHomePage
{
    public interface IBackButtonAware
    {
        bool OnBackButtonPressed();
    }
}
