using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomPopupDialog.Views
{
	public partial class MainPage : ContentPage
	{
        public MainPage ()
		{
			InitializeComponent ();
        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        Vapolia.Lib.Ui.Gesture.SetTapCommand2(GridMain, new Command<Point>(point =>
	            {
	                PopUpBgDialog.TranslationY = point.Y;
	                PopUpBgDialog.TranslationX = point.X;
	                PopUpBgDialog.ShowDialog();

                }));
        }
    }
}