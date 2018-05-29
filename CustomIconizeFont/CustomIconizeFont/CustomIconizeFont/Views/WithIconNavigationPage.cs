using System;
using System.Collections.Generic;
using System.Text;
using CustomIconizeFont.Controls;
using Xamarin.Forms;

namespace CustomIconizeFont.Views
{
    public class WithIconNavigationPage : FlatNavigationPage
    {
        public WithIconNavigationPage(Page root) : base(root)
        {
            //SET THE LOGO FOR YOUR NAVIGATION PAGE
            this.Logo = "test_logo.png";
        }
    }
}
