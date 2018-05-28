using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomIconizeFont.Controls
{
    public class FlatNavigationPage : NavigationPage
    {
        public FlatNavigationPage(Page root)
            : base(root)
        {
            this.BarBackgroundColor = Color.FromHex("#2196F3");
            this.BarTextColor = Color.White;
        }
    }
}
