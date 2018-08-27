using System.Linq;
using BackButtonHomePage.ViewModels;
using Xamarin.Forms;

namespace BackButtonHomePage.Views
{
    public partial class AMasterDetailPage : MasterDetailPage
    {
        private AMasterDetailPageViewModel _vm;

        public AMasterDetailPage()
        {
            InitializeComponent();

            _vm = (AMasterDetailPageViewModel) BindingContext;
        }

        protected override bool OnBackButtonPressed()
        {
            var navStack = Detail.Navigation.NavigationStack;
            var lastNavigated = navStack.Last();

            if (lastNavigated.BindingContext is IBackButtonAware viewModel)
            {
                var isBack = viewModel.OnBackButtonPressed();

                if (!isBack) _vm.NavigateHome();

                return !isBack;
            }    

            return base.OnBackButtonPressed();
        }
    }
}